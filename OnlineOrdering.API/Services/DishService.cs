using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Services
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _db;
        public DishService(AppDbContext db) => _db = db;

        public async Task<List<DishDto>> GetAllAsync()
        {
            //查询时过滤已逻辑删除的菜品
            return await _db.Dishes
                .Where(d => !d.IsDeleted)
                .Select(d => new DishDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Category = d.Category,
                    Price = d.Price,
                    ImagePath = d.ImagePath,
                    SpicyLevel = d.SpicyLevel,
                    IsAvailable = d.IsAvailable,
                    Description = d.Description
                }).ToListAsync();
        }

        public async Task<DishDto?> GetByIdAsync(int id)
        {
            //查询时过滤已逻辑删除的菜品
            var d = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (d == null) return null;
            return new DishDto
            {
                Id = d.Id,
                Name = d.Name,
                Category = d.Category,
                Price = d.Price,
                ImagePath = d.ImagePath,
                SpicyLevel = d.SpicyLevel,
                IsAvailable = d.IsAvailable,
                Description = d.Description
            };
        }

        public async Task<DishDto> CreateAsync(DishCreateUpdateDto dto)
        {
            var dish = new Dish
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                ImagePath = dto.ImagePath,
                SpicyLevel = dto.SpicyLevel,
                IsAvailable = dto.IsAvailable,
                Description = dto.Description,
                IsDeleted = false //新增时默认未删除
            };
            _db.Dishes.Add(dish);
            await _db.SaveChangesAsync();
            return new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                Category = dish.Category,
                Price = dish.Price,
                ImagePath = dish.ImagePath,
                SpicyLevel = dish.SpicyLevel,
                IsAvailable = dish.IsAvailable,
                Description = dish.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, DishCreateUpdateDto dto)
        {
            //只更新未删除的菜品
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (dish == null) return false;
            dish.Name = dto.Name;
            dish.Category = dto.Category;
            dish.Price = dto.Price;
            dish.ImagePath = dto.ImagePath;
            dish.SpicyLevel = dto.SpicyLevel;
            dish.IsAvailable = dto.IsAvailable;
            dish.Description = dto.Description;
            await _db.SaveChangesAsync();
            return true;
        }

        //逻辑删除：仅标记IsDeleted=true
        public async Task<bool> DeleteAsync(int id)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (dish == null) return false;
            dish.IsDeleted = true; //标记为已删除
            await _db.SaveChangesAsync();
            return true;
        }

        //物理删除,直接删除数据库记录
        public async Task<bool> HardDeleteAsync(int id)
        {
            var dish = await _db.Dishes.FindAsync(id);
            if (dish == null) return false;
            _db.Dishes.Remove(dish);
            await _db.SaveChangesAsync();
            return true;
        }

        //恢复逻辑删除的菜品
        public async Task<bool> RestoreDeletedAsync(int id)
        {
            var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted);
            if (dish == null) return false;

            dish.IsDeleted = false; //恢复
            await _db.SaveChangesAsync();
            return true;
        }
    }
}