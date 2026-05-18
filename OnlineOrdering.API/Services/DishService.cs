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
            return await _db.Dishes.Select(d => new DishDto
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
            var d = await _db.Dishes.FindAsync(id);
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
                Description = dto.Description
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
            var dish = await _db.Dishes.FindAsync(id);
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

        public async Task<bool> DeleteAsync(int id)
        {
            var dish = await _db.Dishes.FindAsync(id);
            if (dish == null) return false;
            _db.Dishes.Remove(dish);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}