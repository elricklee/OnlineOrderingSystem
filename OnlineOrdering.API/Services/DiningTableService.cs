using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services
{
    public class DiningTableService : IDiningTableService
    {
        private readonly AppDbContext _db;

        public DiningTableService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<DiningTableDto>> GetAllAsync(bool availableOnly = false)
        {
            var query = _db.DiningTables.AsQueryable();
            if (availableOnly)
            {
                query = query.Where(x => x.IsEnabled && (x.Status == "Available" || string.IsNullOrEmpty(x.Status)));
            }

            return await query
                .OrderBy(x => x.TableNumber)
                .Select(MapToDtoExpression())
                .ToListAsync();
        }

        public async Task<DiningTableDto?> GetByIdAsync(int id)
        {
            return await _db.DiningTables
                .Where(x => x.Id == id)
                .Select(MapToDtoExpression())
                .FirstOrDefaultAsync();
        }

        public async Task<DiningTableDto> CreateAsync(DiningTableCreateUpdateDto dto)
        {
            var entity = new DiningTable();
            ApplyChanges(entity, dto);

            _db.DiningTables.Add(entity);
            await _db.SaveChangesAsync();
            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, DiningTableCreateUpdateDto dto)
        {
            var entity = await _db.DiningTables.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            ApplyChanges(entity, dto);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.DiningTables.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            if (entity.IsOccupied)
            {
                throw new InvalidOperationException("当前餐桌正在使用中，不能删除。");
            }

            _db.DiningTables.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        private static void ApplyChanges(DiningTable entity, DiningTableCreateUpdateDto dto)
        {
            entity.TableNumber = dto.TableNumber.Trim();
            entity.SeatCount = dto.SeatCount;
            entity.IsOccupied = dto.IsOccupied;
            entity.IsEnabled = dto.IsEnabled;
        }

        private static DiningTableDto MapToDto(DiningTable entity)
        {
            return new DiningTableDto
            {
                Id = entity.Id,
                TableNumber = entity.TableNumber,
                SeatCount = entity.SeatCount,
                RemainingSeats = entity.SeatCount - entity.CurrentOccupiedSeats,
                IsOccupied = entity.IsOccupied,
                IsEnabled = entity.IsEnabled
            };
        }

        private static System.Linq.Expressions.Expression<Func<DiningTable, DiningTableDto>> MapToDtoExpression()
        {
            return entity => new DiningTableDto
            {
                Id = entity.Id,
                TableNumber = entity.TableNumber,
                SeatCount = entity.SeatCount,
                RemainingSeats = entity.SeatCount - entity.CurrentOccupiedSeats,
                IsOccupied = entity.IsOccupied,
                IsEnabled = entity.IsEnabled
            };
        }
    }
}
