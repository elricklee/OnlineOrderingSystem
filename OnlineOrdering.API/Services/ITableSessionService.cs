using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services;

public interface ITableSessionService
{
    Task<TableSessionDto> CreateAsync(TableSessionCreateDto dto, int? openedByUserId, string? remark = null);
    Task<TableSessionDto?> CloseAsync(int id, TableSessionCloseDto dto, int? closedByUserId);
    Task<TableSessionDto?> GetCurrentByTableIdAsync(int diningTableId);
}
