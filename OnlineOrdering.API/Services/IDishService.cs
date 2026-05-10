using OnlineOrdering.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Services
{
    public interface IDishService
    {
        Task<List<DishDto>> GetAllAsync();
        Task<DishDto?> GetByIdAsync(int id);
        Task<DishDto> CreateAsync(DishCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, DishCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}