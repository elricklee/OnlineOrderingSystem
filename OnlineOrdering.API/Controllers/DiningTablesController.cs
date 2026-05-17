using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/diningtables")]
    [ApiController]
    public class DiningTablesController : ControllerBase
    {
        private readonly IDiningTableService _service;

        public DiningTablesController(IDiningTableService service)
        {
            _service = service;
        }

        [HttpGet]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取餐桌列表失败：{ex.Message}" });
            }
        }

        [HttpGet("available")]
        [RequireClientRole(UserRoles.Customer)]
        public async Task<IActionResult> GetAvailable()
        {
            try
            {
                return Ok(await _service.GetAllAsync(availableOnly: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取可用餐桌列表失败：{ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dto = await _service.GetByIdAsync(id);
                return dto == null ? NotFound() : Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取餐桌详情失败：{ex.Message}" });
            }
        }

        [HttpPost]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Create(DiningTableCreateUpdateDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"创建餐桌失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Update(int id, DiningTableCreateUpdateDto dto)
        {
            try
            {
                var ok = await _service.UpdateAsync(id, dto);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"更新餐桌失败：{ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ok = await _service.DisableAsync(id);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"删除餐桌失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}/disable")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                var ok = await _service.DisableAsync(id);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"停用餐桌失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}/restore")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                var ok = await _service.RestoreAsync(id);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"恢复餐桌失败：{ex.Message}" });
            }
        }
    }
}
