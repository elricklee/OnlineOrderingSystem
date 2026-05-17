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
                query = query.Where(x => x.IsEnabled && x.Status == DiningTableStatuses.Available);
            }

            return await query
                .OrderBy(x => x.TableNumber)
                .Select(entity => new DiningTableDto
                {
                    Id = entity.Id,
                    TableNumber = entity.TableNumber,
                    SeatCount = entity.SeatCount,
                    RemainingSeats = entity.SeatCount - entity.CurrentOccupiedSeats,
                    IsOccupied = entity.CurrentOccupiedSeats > 0 || entity.Status == DiningTableStatuses.Occupied,
                    IsEnabled = entity.IsEnabled,
                    Status = string.IsNullOrWhiteSpace(entity.Status) ? DiningTableStatuses.Available : entity.Status,
                    CurrentOccupiedSeats = entity.CurrentOccupiedSeats,
                    CurrentSessionId = _db.TableSessions
                        .Where(s => s.DiningTableId == entity.Id && s.Status == TableSessionStatuses.Open)
                        .OrderByDescending(s => s.OpenedAt)
                        .Select(s => (int?)s.Id)
                        .FirstOrDefault(),
                    CurrentSessionNo = _db.TableSessions
                        .Where(s => s.DiningTableId == entity.Id && s.Status == TableSessionStatuses.Open)
                        .OrderByDescending(s => s.OpenedAt)
                        .Select(s => s.SessionNo)
                        .FirstOrDefault(),
                    IsDeleted = entity.IsDeleted
                })
                .ToListAsync();
        }

        public async Task<DiningTableDto?> GetByIdAsync(int id)
        {
            return (await GetAllAsync()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<DiningTableDto> CreateAsync(DiningTableCreateUpdateDto dto)
        {
            var entity = new DiningTable();
            ApplyChanges(entity, dto);
            entity.Status = entity.IsEnabled ? DiningTableStatuses.Available : DiningTableStatuses.Disabled;
            entity.CurrentOccupiedSeats = 0;
            entity.IsOccupied = false;
            entity.IsDeleted = false;

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

            var isBusy = await IsTableBusyAsync(entity.Id, entity);

            if (entity.CurrentOccupiedSeats > entity.SeatCount && dto.SeatCount < entity.CurrentOccupiedSeats)
            {
                throw new InvalidOperationException("当前餐桌已有顾客占用，座位数不能小于当前占用人数。");
            }

            if (!dto.IsEnabled && isBusy)
            {
                throw new InvalidOperationException("当前餐桌正在使用中，不能停用。");
            }

            if (isBusy &&
                (!string.Equals(entity.TableNumber, dto.TableNumber.Trim(), StringComparison.OrdinalIgnoreCase) ||
                 entity.SeatCount != dto.SeatCount))
            {
                throw new InvalidOperationException("当前餐桌正在使用中，不能修改桌号或座位数。");
            }

            ApplyChanges(entity, dto);
            entity.IsOccupied = entity.CurrentOccupiedSeats > 0;
            entity.Status = !entity.IsEnabled
                ? DiningTableStatuses.Disabled
                : entity.CurrentOccupiedSeats > 0
                    ? DiningTableStatuses.Occupied
                    : DiningTableStatuses.Available;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableAsync(int id)
        {
            var entity = await _db.DiningTables.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            if (await IsTableBusyAsync(entity.Id, entity))
            {
                throw new InvalidOperationException("当前餐桌正在使用中，不能停用。");
            }

            entity.IsEnabled = false;
            entity.IsOccupied = false;
            entity.CurrentOccupiedSeats = 0;
            entity.Status = DiningTableStatuses.Disabled;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreAsync(int id)
        {
            var entity = await _db.DiningTables
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = false;
            entity.IsEnabled = true;
            entity.DeletedAt = null;
            entity.DeletedByUserId = null;
            entity.Status = entity.CurrentOccupiedSeats > 0 ? DiningTableStatuses.Occupied : DiningTableStatuses.Available;
            entity.IsOccupied = entity.CurrentOccupiedSeats > 0;

            await _db.SaveChangesAsync();
            return true;
        }

        private async Task<bool> IsTableBusyAsync(int diningTableId, DiningTable entity)
        {
            if (entity.CurrentOccupiedSeats > 0 || entity.Status == DiningTableStatuses.Occupied)
            {
                return true;
            }

            return await _db.TableSessions.AnyAsync(s => s.DiningTableId == diningTableId && s.Status == TableSessionStatuses.Open);
        }

        private static void ApplyChanges(DiningTable entity, DiningTableCreateUpdateDto dto)
        {
            entity.TableNumber = dto.TableNumber.Trim().ToUpperInvariant();
            entity.SeatCount = dto.SeatCount;
            entity.IsEnabled = dto.IsEnabled;
        }

        private static DiningTableDto MapToDto(DiningTable entity)
        {
            return new DiningTableDto
            {
                Id = entity.Id,
                TableNumber = entity.TableNumber,
                SeatCount = entity.SeatCount,
                RemainingSeats = Math.Max(0, entity.SeatCount - entity.CurrentOccupiedSeats),
                IsOccupied = entity.CurrentOccupiedSeats > 0 || entity.Status == DiningTableStatuses.Occupied,
                IsEnabled = entity.IsEnabled,
                Status = string.IsNullOrWhiteSpace(entity.Status) ? DiningTableStatuses.Available : entity.Status,
                CurrentOccupiedSeats = entity.CurrentOccupiedSeats,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
