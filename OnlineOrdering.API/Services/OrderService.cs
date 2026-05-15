using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        public OrderService(AppDbContext db) => _db = db;

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                Phone = dto.Phone,
                OrderType = dto.OrderType,
                TableNumber = dto.TableNumber,
                Address = dto.Address,
                DeliveryFee = dto.DeliveryFee,
                Note = dto.Note,
                IsDeleted = false //新增时默认未删除
            };

            decimal total = 0;
            foreach (var item in dto.OrderItems)
            {
                //下单时校验菜品是否未删除且可用
                var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == item.DishId && !d.IsDeleted && d.IsAvailable);
                if (dish == null)
                {
                    throw new KeyNotFoundException($"菜品ID {item.DishId} 不存在、已删除或不可用");
                }
                var orderItem = new OrderItem
                {
                    DishId = item.DishId,
                    DishName = dish!.Name,
                    Price = dish.Price,
                    Quantity = item.Quantity
                };
                order.OrderItems.Add(orderItem);
                total += dish.Price * item.Quantity;
            }
            order.TotalAmount = total + order.DeliveryFee;
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return MapToDto(order);
        }

        public async Task<OrderDto?> UpdateOrderStatusAsync(int id, string status)
        {
            var order = await _db.Orders.Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (order == null) return null;
            order.Status = status;
            await _db.SaveChangesAsync();
            return MapToDto(order);
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var list = await _db.Orders.Include(x => x.OrderItems)
                .Where(o => !o.IsDeleted)
                .ToListAsync();
            return list.Select(MapToDto).ToList();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _db.Orders.Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return order == null ? null : MapToDto(order);
        }

        //逻辑删除订单
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
            if (order == null) return false;
            order.IsDeleted = true; //标记为已删除
            await _db.SaveChangesAsync();
            return true;
        }

        //物理删除订单
        public async Task<bool> HardDeleteOrderAsync(int id)
        {
            var order = await _db.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return false;
            //先删除订单项，再删除订单
            _db.OrderItems.RemoveRange(order.OrderItems);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return true;
        }

        //恢复逻辑删除
        public async Task<bool> RestoreOrderAsync(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id && o.IsDeleted);
            if (order == null) return false;

            order.IsDeleted = false;
            await _db.SaveChangesAsync();
            return true;
        }

        private OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                TableNumber = order.TableNumber,
                Note = order.Note,
                TotalAmount = order.TotalAmount,
                DeliveryFee = order.DeliveryFee,
                OrderType = order.OrderType,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems.Select(i => new OrderItemResponseDto
                {
                    Id = i.Id,
                    DishId = i.DishId,
                    DishName = i.DishName,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}