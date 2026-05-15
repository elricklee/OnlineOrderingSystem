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
        public async Task<IActionResult> GetAll() => Ok(await _dishService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _dishService.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DishCreateUpdateDto dto)
        {
            var res = await _dishService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DishCreateUpdateDto dto)
        {
            var ok = await _dishService.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        //Âß¼­É¾³ý
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _dishService.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

        //ÎïÀíÉ¾³ý
        [HttpDelete("{id}/hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var ok = await _dishService.HardDeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

        //»Ö¸´Âß¼­É¾³ýµÄ²ËÆ·
        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var ok = await _dishService.RestoreDeletedAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}