using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto dto);
        Task<OrderDto?> UpdateOrderStatusAsync(int id, string status);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<bool> DeleteOrderAsync(int id); //Âß¼­É¾³ý¶©µ¥
        Task<bool> HardDeleteOrderAsync(int id); //ÎïÀíÉ¾³ý¶©µ¥
        Task<bool> RestoreOrderAsync(int id);//»Ö¸´Âß¼­É¾³ý
    }
}