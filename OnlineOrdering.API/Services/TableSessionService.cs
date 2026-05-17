using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services;

public class TableSessionService : ITableSessionService
{
    private readonly AppDbContext _db;

    public TableSessionService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TableSessionDto> CreateAsync(TableSessionCreateDto dto, int? openedByUserId, string? remark = null)
    {
        var table = await _db.DiningTables.FirstOrDefaultAsync(t => t.Id == dto.DiningTableId && t.IsEnabled);
        if (table == null)
        {
            throw new InvalidOperationException("餐桌不存在或已停用。");
        }

        var openSession = await _db.TableSessions
            .FirstOrDefaultAsync(s => s.DiningTableId == dto.DiningTableId && s.Status == TableSessionStatuses.Open);
        if (openSession != null)
        {
            throw new InvalidOperationException("该餐桌当前已有进行中的桌次。");
        }

        if (dto.PartySize <= 0 || dto.PartySize > table.SeatCount)
        {
            throw new InvalidOperationException($"当前桌台最多容纳 {table.SeatCount} 人。");
        }

        var session = new TableSession
        {
            DiningTableId = table.Id,
            SessionNo = GenerateSessionNo(table.TableNumber),
            PartySize = dto.PartySize,
            Status = TableSessionStatuses.Open,
            OpenedAt = DateTime.Now,
            OpenedByUserId = openedByUserId,
            Remark = string.IsNullOrWhiteSpace(dto.Remark) ? remark : dto.Remark.Trim()
        };

        _db.TableSessions.Add(session);

        table.CurrentOccupiedSeats = dto.PartySize;
        table.IsOccupied = true;
        table.Status = DiningTableStatuses.Occupied;

        await _db.SaveChangesAsync();
        return await GetCurrentByTableIdAsync(table.Id) ?? MapToDto(session, table.TableNumber);
    }

    public async Task<TableSessionDto?> CloseAsync(int id, TableSessionCloseDto dto, int? closedByUserId)
    {
        var session = await _db.TableSessions
            .Include(s => s.DiningTable)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (session == null)
        {
            return null;
        }

        if (session.Status != TableSessionStatuses.Open)
        {
            return MapToDto(session, session.DiningTable?.TableNumber);
        }

        var hasActiveOrder = await _db.Orders.AnyAsync(o =>
            o.TableSessionId == session.Id &&
            o.Status != OrderStatuses.Completed &&
            o.Status != OrderStatuses.Cancelled);
        if (hasActiveOrder)
        {
            throw new InvalidOperationException("当前桌次仍有关联中的有效订单，不能关闭。");
        }

        session.Status = TableSessionStatuses.Closed;
        session.ClosedAt = DateTime.Now;
        session.ClosedByUserId = closedByUserId;
        if (!string.IsNullOrWhiteSpace(dto.Remark))
        {
            session.Remark = dto.Remark.Trim();
        }

        if (session.DiningTable != null)
        {
            session.DiningTable.CurrentOccupiedSeats = 0;
            session.DiningTable.IsOccupied = false;
            session.DiningTable.Status = session.DiningTable.IsEnabled
                ? DiningTableStatuses.Available
                : DiningTableStatuses.Disabled;
        }

        await _db.SaveChangesAsync();
        return MapToDto(session, session.DiningTable?.TableNumber);
    }

    public async Task<TableSessionDto?> GetCurrentByTableIdAsync(int diningTableId)
    {
        return await _db.TableSessions
            .Include(s => s.DiningTable)
            .Where(s => s.DiningTableId == diningTableId && s.Status == TableSessionStatuses.Open)
            .OrderByDescending(s => s.OpenedAt)
            .Select(s => new TableSessionDto
            {
                Id = s.Id,
                DiningTableId = s.DiningTableId,
                TableNumber = s.DiningTable != null ? s.DiningTable.TableNumber : string.Empty,
                SessionNo = s.SessionNo,
                PartySize = s.PartySize,
                Status = s.Status,
                OpenedAt = s.OpenedAt,
                ClosedAt = s.ClosedAt,
                Remark = s.Remark
            })
            .FirstOrDefaultAsync();
    }

    private static TableSessionDto MapToDto(TableSession session, string? tableNumber)
    {
        return new TableSessionDto
        {
            Id = session.Id,
            DiningTableId = session.DiningTableId,
            TableNumber = tableNumber ?? string.Empty,
            SessionNo = session.SessionNo,
            PartySize = session.PartySize,
            Status = session.Status,
            OpenedAt = session.OpenedAt,
            ClosedAt = session.ClosedAt,
            Remark = session.Remark
        };
    }

    private static string GenerateSessionNo(string tableNumber)
    {
        return $"TS-{tableNumber}-{DateTime.Now:yyyyMMddHHmmss}";
    }
}
