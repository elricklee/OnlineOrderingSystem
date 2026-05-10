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
                Note = dto.Note
            };

            decimal total = 0;
            foreach (var item in dto.OrderItems)
            {
                var dish = await _db.Dishes.FindAsync(item.DishId);
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
            var order = await _db.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
            if (order == null) return null;
            order.Status = status;
            await _db.SaveChangesAsync();
            return MapToDto(order);
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var list = await _db.Orders.Include(x => x.OrderItems).ToListAsync();
            return list.Select(MapToDto).ToList();
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