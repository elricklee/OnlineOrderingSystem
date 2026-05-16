using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
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

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ok = await _dishService.DeleteAsync(id);
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

        //物理删除
        [HttpDelete("{id}/hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                var ok = await _dishService.HardDeleteAsync(id);
                return ok ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"物理删除菜品失败：{ex.Message}" });
            }
        }

        //恢复逻辑删除的菜品
        [HttpPut("{id}/restore")]
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
    }
}
