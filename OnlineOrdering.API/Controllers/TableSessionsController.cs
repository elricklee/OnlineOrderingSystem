using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers;

[ApiController]
[Route("api/tablesessions")]
[RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
public class TableSessionsController : ControllerBase
{
    private readonly ITableSessionService _service;

    public TableSessionsController(ITableSessionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TableSessionCreateDto dto)
    {
        try
        {
            var userId = ClientRequestContext.GetUserId(HttpContext);
            var session = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetCurrentByTable), new { diningTableId = dto.DiningTableId }, session);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"创建桌次失败：{ex.Message}" });
        }
    }

    [HttpPut("{id}/close")]
    public async Task<IActionResult> Close(int id, [FromBody] TableSessionCloseDto dto)
    {
        try
        {
            var userId = ClientRequestContext.GetUserId(HttpContext);
            var session = await _service.CloseAsync(id, dto, userId);
            return session == null ? NotFound(new { message = "桌次不存在" }) : Ok(session);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"关闭桌次失败：{ex.Message}" });
        }
    }

    [HttpGet("/api/diningtables/{diningTableId}/sessions/current")]
    public async Task<IActionResult> GetCurrentByTable(int diningTableId)
    {
        try
        {
            var session = await _service.GetCurrentByTableIdAsync(diningTableId);
            return session == null ? NotFound(new { message = "当前餐桌没有进行中的桌次" }) : Ok(session);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"获取当前桌次失败：{ex.Message}" });
        }
    }
}
