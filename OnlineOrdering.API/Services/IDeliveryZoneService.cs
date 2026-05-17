using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IDeliveryZoneService
    {
        Task<List<DeliveryZoneDto>> GetAllAsync(bool activeOnly = false);
        Task<DeliveryZoneDto?> GetByIdAsync(int id);
        Task<DeliveryZoneDto> CreateAsync(DeliveryZoneCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, DeliveryZoneCreateUpdateDto dto);
        Task<bool> DisableAsync(int id);
        Task<bool> RestoreAsync(int id);
    }
}
