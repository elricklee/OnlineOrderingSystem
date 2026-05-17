using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishesController(IDishService dishService) => _dishService = dishService;

        [HttpGet]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _dishService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取菜品列表失败：{ex.Message}" });
            }
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            try
            {
                return Ok(await _dishService.GetAvailableAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取可售菜品失败：{ex.Message}" });
            }
        }

        [HttpGet("recycle-bin")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetRecycleBin()
        {
            try
            {
                return Ok(await _dishService.GetRecycleBinAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取已删除菜品失败：{ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dto = await _dishService.GetByIdAsync(id);
                return dto == null ? NotFound() : Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取菜品详情失败：{ex.Message}" });
            }
        }

        [HttpPost]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Create(DishCreateUpdateDto dto)
        {
            try
            {
                var res = await _dishService.CreateAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"创建菜品失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Update(int id, DishCreateUpdateDto dto)
        {
            try
            {
                var ok = await _dishService.UpdateAsync(id, dto);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"更新菜品失败：{ex.Message}" });
            }
        }

        //逻辑删除
        [HttpDelete("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Delete(int id, [FromBody] DishDeleteDto? dto)
        {
            try
            {
                var ok = await _dishService.DeleteAsync(id, dto);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"删除菜品失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}/restore")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                var ok = await _dishService.RestoreDeletedAsync(id);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"恢复菜品失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}/sale-status")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> UpdateSaleStatus(int id, [FromBody] DishSaleStatusUpdateDto dto)
        {
            try
            {
                var ok = await _dishService.UpdateSaleStatusAsync(id, dto.SaleStatus);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"更新菜品销售状态失败：{ex.Message}" });
            }
        }
    }
}
