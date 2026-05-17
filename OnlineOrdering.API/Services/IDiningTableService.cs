using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IDiningTableService
    {
        Task<List<DiningTableDto>> GetAllAsync(bool availableOnly = false);
        Task<DiningTableDto?> GetByIdAsync(int id);
        Task<DiningTableDto> CreateAsync(DiningTableCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, DiningTableCreateUpdateDto dto);
        Task<bool> DisableAsync(int id);
        Task<bool> RestoreAsync(int id);
    }
}
