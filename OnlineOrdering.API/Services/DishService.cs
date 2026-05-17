using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _db;

        public DishService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<DishDto>> GetAllAsync()
        {
            return await _db.Dishes
                .Include(d => d.CategoryEntity)
                .OrderBy(d => d.SortOrder)
                .ThenBy(d => d.Id)
                .Select(MapExpression())
                .ToListAsync();
        }

        public async Task<List<DishDto>> GetAvailableAsync()
        {
            return await _db.Dishes
                .Include(d => d.CategoryEntity)
                .Where(d => d.IsAvailable && d.SaleStatus == DishSaleStatuses.OnSale)
                .OrderBy(d => d.SortOrder)
                .ThenBy(d => d.Id)
                .Select(MapExpression())
                .ToListAsync();
        }

        public async Task<List<DishDto>> GetRecycleBinAsync()
        {
            return await _db.Dishes
                .IgnoreQueryFilters()
                .Include(d => d.CategoryEntity)
                .Where(d => d.IsDeleted)
                .OrderByDescending(d => d.DeletedAt)
                .ThenByDescending(d => d.Id)
                .Select(MapExpression())
                .ToListAsync();
        }

        public async Task<DishDto?> GetByIdAsync(int id)
        {
            return await _db.Dishes
                .Include(d => d.CategoryEntity)
                .Where(d => d.Id == id)
                .Select(MapExpression())
                .FirstOrDefaultAsync();
        }

        public async Task<DishDto> CreateAsync(DishCreateUpdateDto dto)
        {
            var dish = new Dish();
            await ApplyChangesAsync(dish, dto);
            dish.CreatedAt = DateTime.Now;
            dish.UpdatedAt = DateTime.Now;
            dish.IsDeleted = false;

            _db.Dishes.Add(dish);
            await _db.SaveChangesAsync();
            return MapToDto(dish);
        }

        public async Task<bool> UpdateAsync(int id, DishCreateUpdateDto dto)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (dish == null)
            {
                return false;
            }

            await ApplyChangesAsync(dish, dto);
            dish.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, DishDeleteDto? dto)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (dish == null)
            {
                return false;
            }

            dish.IsDeleted = true;
            dish.IsAvailable = false;
            dish.SaleStatus = DishSaleStatuses.OffSale;
            dish.DeletedAt = DateTime.Now;
            dish.DeletedByUserId = null;
            dish.DeleteReason = string.IsNullOrWhiteSpace(dto?.DeleteReason) ? "管理员删除菜品" : dto!.DeleteReason!.Trim();
            dish.UpdatedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreDeletedAsync(int id)
        {
            var dish = await _db.Dishes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted);
            if (dish == null)
            {
                return false;
            }

            dish.IsDeleted = false;
            dish.DeletedAt = null;
            dish.DeletedByUserId = null;
            dish.DeleteReason = null;
            dish.UpdatedAt = DateTime.Now;

            if (string.IsNullOrWhiteSpace(dish.SaleStatus))
            {
                dish.SaleStatus = DishSaleStatuses.OffSale;
            }

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSaleStatusAsync(int id, string saleStatus)
        {
            if (saleStatus != DishSaleStatuses.OnSale &&
                saleStatus != DishSaleStatuses.OffSale &&
                saleStatus != DishSaleStatuses.OutOfStock)
            {
                throw new InvalidOperationException("不支持的菜品销售状态。");
            }

            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (dish == null)
            {
                return false;
            }

            dish.SaleStatus = saleStatus;
            dish.IsAvailable = saleStatus == DishSaleStatuses.OnSale;
            dish.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        private async Task ApplyChangesAsync(Dish dish, DishCreateUpdateDto dto)
        {
            var category = await ResolveCategoryAsync(dto);

            dish.Name = dto.Name.Trim();
            dish.CategoryId = category?.Id;
            dish.Category = category?.Name ?? dto.Category.Trim();
            dish.Price = dto.Price;
            dish.ImagePath = string.IsNullOrWhiteSpace(dto.ImagePath) ? null : dto.ImagePath.Trim();
            dish.SpicyLevel = dto.SpicyLevel;
            dish.Description = string.IsNullOrWhiteSpace(dto.Description) ? null : dto.Description.Trim();
            dish.SortOrder = dto.SortOrder;
            dish.SaleStatus = string.IsNullOrWhiteSpace(dto.SaleStatus) ? DishSaleStatuses.OnSale : dto.SaleStatus.Trim();
            dish.IsAvailable = dto.IsAvailable && dish.SaleStatus == DishSaleStatuses.OnSale;
        }

        private async Task<DishCategory?> ResolveCategoryAsync(DishCreateUpdateDto dto)
        {
            if (dto.CategoryId.HasValue)
            {
                var categoryEntity = await _db.DishCategories.FirstOrDefaultAsync(c => c.Id == dto.CategoryId.Value && c.IsEnabled);
                if (categoryEntity == null)
                {
                    throw new InvalidOperationException("所选菜品分类不存在或已停用。");
                }

                return categoryEntity;
            }

            var categoryName = dto.Category.Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new InvalidOperationException("菜品分类不能为空。");
            }

            return await _db.DishCategories.FirstOrDefaultAsync(c => c.Name == categoryName && c.IsEnabled);
        }

        private static DishDto MapToDto(Dish dish)
        {
            return new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                CategoryId = dish.CategoryId,
                Category = dish.Category,
                Price = dish.Price,
                ImagePath = dish.ImagePath,
                SpicyLevel = dish.SpicyLevel,
                IsAvailable = dish.IsAvailable,
                Description = dish.Description,
                SaleStatus = dish.SaleStatus,
                SortOrder = dish.SortOrder,
                DeletedAt = dish.DeletedAt,
                DeleteReason = dish.DeleteReason
            };
        }

        private static System.Linq.Expressions.Expression<Func<Dish, DishDto>> MapExpression()
        {
            return dish => new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                CategoryId = dish.CategoryId,
                Category = dish.Category,
                Price = dish.Price,
                ImagePath = dish.ImagePath,
                SpicyLevel = dish.SpicyLevel,
                IsAvailable = dish.IsAvailable,
                Description = dish.Description,
                SaleStatus = dish.SaleStatus,
                SortOrder = dish.SortOrder,
                DeletedAt = dish.DeletedAt,
                DeleteReason = dish.DeleteReason
            };
        }
    }
}
