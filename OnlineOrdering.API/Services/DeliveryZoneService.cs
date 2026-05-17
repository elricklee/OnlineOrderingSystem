using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services
{
    public class DeliveryZoneService : IDeliveryZoneService
    {
        private readonly AppDbContext _db;

        public DeliveryZoneService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<DeliveryZoneDto>> GetAllAsync(bool activeOnly = false)
        {
            var query = _db.DeliveryZones.AsQueryable();
            if (activeOnly)
            {
                query = query.Where(x => x.IsActive);
            }

            return await query
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Province)
                .ThenBy(x => x.City)
                .ThenBy(x => x.District)
                .Select(MapExpression())
                .ToListAsync();
        }

        public async Task<DeliveryZoneDto?> GetByIdAsync(int id)
        {
            return await _db.DeliveryZones
                .Where(x => x.Id == id)
                .Select(MapExpression())
                .FirstOrDefaultAsync();
        }

        public async Task<DeliveryZoneDto> CreateAsync(DeliveryZoneCreateUpdateDto dto)
        {
            var entity = new DeliveryZone();
            ApplyChanges(entity, dto);
            entity.IsDeleted = false;
            entity.DeletedAt = null;
            entity.DeletedByUserId = null;

            _db.DeliveryZones.Add(entity);
            await _db.SaveChangesAsync();
            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, DeliveryZoneCreateUpdateDto dto)
        {
            var entity = await _db.DeliveryZones.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            ApplyChanges(entity, dto);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableAsync(int id)
        {
            var entity = await _db.DeliveryZones.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            entity.IsActive = false;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreAsync(int id)
        {
            var entity = await _db.DeliveryZones
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = false;
            entity.IsActive = true;
            entity.DeletedAt = null;
            entity.DeletedByUserId = null;
            await _db.SaveChangesAsync();
            return true;
        }

        private static void ApplyChanges(DeliveryZone entity, DeliveryZoneCreateUpdateDto dto)
        {
            entity.Province = dto.Province.Trim();
            entity.City = dto.City.Trim();
            entity.District = dto.District.Trim();
            entity.DeliveryFee = dto.DeliveryFee;
            entity.IsActive = dto.IsActive;
            entity.SortOrder = dto.SortOrder;
        }

        private static DeliveryZoneDto MapToDto(DeliveryZone entity)
        {
            return new DeliveryZoneDto
            {
                Id = entity.Id,
                Province = entity.Province,
                City = entity.City,
                District = entity.District,
                DeliveryFee = entity.DeliveryFee,
                IsActive = entity.IsActive,
                SortOrder = entity.SortOrder,
                DisplayName = $"{entity.Province} / {entity.City} / {entity.District}",
                IsDeleted = entity.IsDeleted
            };
        }

        private static System.Linq.Expressions.Expression<Func<DeliveryZone, DeliveryZoneDto>> MapExpression()
        {
            return entity => new DeliveryZoneDto
            {
                Id = entity.Id,
                Province = entity.Province,
                City = entity.City,
                District = entity.District,
                DeliveryFee = entity.DeliveryFee,
                IsActive = entity.IsActive,
                SortOrder = entity.SortOrder,
                DisplayName = entity.Province + " / " + entity.City + " / " + entity.District,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
