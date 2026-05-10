using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            var result = orders.Select(MapToOrderDto).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(MapToOrderDto(order));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderCreateDto dto)
        {
            if (dto.OrderItems == null || dto.OrderItems.Count == 0)
            {
                return BadRequest("订单明细不能为空");
            }

            var dishIds = dto.OrderItems
                .Select(item => item.DishId)
                .Distinct()
                .ToList();

            var dishes = await _context.Dishes
                .Where(dish => dishIds.Contains(dish.Id))
                .ToListAsync();

            if (dishes.Count != dishIds.Count)
            {
                return BadRequest("部分菜品不存在，请检查 dishId 是否正确");
            }

            var order = new Order
            {
                CustomerName = dto.CustomerName,
                Phone = dto.Phone,
                Address = dto.Address,
                CreatedAt = DateTime.Now,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in dto.OrderItems)
            {
                if (itemDto.Quantity <= 0)
                {
                    return BadRequest("菜品数量必须大于 0");
                }

                var dish = dishes.First(d => d.Id == itemDto.DishId);

                var orderItem = new OrderItem
                {
                    DishId = dish.Id,
                    DishName = dish.Name,
                    Price = dish.Price,
                    Quantity = itemDto.Quantity
                };

                order.OrderItems.Add(orderItem);
            }

            order.TotalAmount = order.OrderItems.Sum(item => item.Price * item.Quantity);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var savedOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstAsync(o => o.Id == order.Id);

            var result = MapToOrderDto(savedOrder);

            return CreatedAtAction(nameof(GetOrder), new { id = result.Id }, result);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(int id, [FromBody] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BadRequest("订单状态不能为空");
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            order.Status = status;
            await _context.SaveChangesAsync();

            return Ok(MapToOrderDto(order));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static OrderDto MapToOrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    DishId = item.DishId,
                    DishName = item.DishName,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}