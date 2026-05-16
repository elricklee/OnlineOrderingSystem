using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/deliveryzones")]
    [ApiController]
    public class DeliveryZonesController : ControllerBase
    {
        private readonly IDeliveryZoneService _service;

        public DeliveryZonesController(IDeliveryZoneService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("active")]
        public async Task<IActionResult> GetActive() => Ok(await _service.GetAllAsync(activeOnly: true));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryZoneCreateUpdateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DeliveryZoneCreateUpdateDto dto)
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
