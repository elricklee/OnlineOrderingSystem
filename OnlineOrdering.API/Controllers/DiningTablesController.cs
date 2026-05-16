using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
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
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable() => Ok(await _service.GetAllAsync(availableOnly: true));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiningTableCreateUpdateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DiningTableCreateUpdateDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
