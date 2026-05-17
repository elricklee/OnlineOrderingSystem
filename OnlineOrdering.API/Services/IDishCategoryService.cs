using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services;

public interface IDishCategoryService
{
    Task<List<DishCategoryDto>> GetAllAsync(bool enabledOnly = false);
}
