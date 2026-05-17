using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services;

public class DishCategoryService : IDishCategoryService
{
    private readonly AppDbContext _db;

    public DishCategoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<DishCategoryDto>> GetAllAsync(bool enabledOnly = false)
    {
        var query = _db.DishCategories.AsQueryable();
        if (enabledOnly)
        {
            query = query.Where(c => c.IsEnabled);
        }

        return await query
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Id)
            .Select(c => new DishCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                SortOrder = c.SortOrder,
                IsEnabled = c.IsEnabled
            })
            .ToListAsync();
    }
}
