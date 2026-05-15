using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService) => _orderService = orderService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAllOrdersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            var order = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = order.Id }, order);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] OrderUpdateStatusDto dto)
        {
            var order = await _orderService.UpdateOrderStatusAsync(id, dto.Status);
            return order == null ? NotFound() : Ok(order);
        }

        //Âß¼­É¾³ý¶©µ¥
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _orderService.DeleteOrderAsync(id);
            return ok ? NoContent() : NotFound();
        }

        //ÎïÀíÉ¾³ý¶©µ¥
        [HttpDelete("{id}/hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var ok = await _orderService.HardDeleteOrderAsync(id);
            return ok ? NoContent() : NotFound();
        }

        //»Ö¸´Âß¼­É¾³ý
        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreOrder(int id)
        {
            var ok = await _orderService.RestoreOrderAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}