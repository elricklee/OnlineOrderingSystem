using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto dto);
        Task<OrderDto?> UpdateOrderStatusAsync(int id, string status, string? cancelReason = null);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> HardDeleteOrderAsync(int id);
        Task<bool> RestoreOrderAsync(int id);
    }
}