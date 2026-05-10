using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto dto);
        Task<OrderDto?> UpdateOrderStatusAsync(int id, string status);
        Task<List<OrderDto>> GetAllOrdersAsync();
    }
}