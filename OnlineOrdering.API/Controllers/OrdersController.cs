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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _orderService.GetAllOrdersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取订单列表失败：{ex.Message}" });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取用户订单失败：{ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return order == null ? NotFound(new { message = "订单不存在" }) : Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取订单详情失败：{ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            try
            {
                var order = await _orderService.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(GetAll), new { id = order.Id }, order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"创建订单失败：{ex.Message}" });
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] OrderUpdateStatusDto dto)
        {
            try
            {
                var order = await _orderService.UpdateOrderStatusAsync(id, dto.Status, dto.CancelReason);
                return order == null ? NotFound(new { message = "订单不存在" }) : Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"更新订单状态失败：{ex.Message}" });
            }
        }

        //逻辑删除订单
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ok = await _orderService.DeleteOrderAsync(id);
                return ok ? NoContent() : NotFound(new { message = "订单不存在" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"删除订单失败：{ex.Message}" });
            }
        }

        //物理删除订单
        [HttpDelete("{id}/hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                var ok = await _orderService.HardDeleteOrderAsync(id);
                return ok ? NoContent() : NotFound(new { message = "订单不存在" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"删除订单失败：{ex.Message}" });
            }
        }

        //恢复逻辑删除
        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreOrder(int id)
        {
            try
            {
                var ok = await _orderService.RestoreOrderAsync(id);
                return ok ? NoContent() : NotFound(new { message = "订单不存在" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"恢复订单失败：{ex.Message}" });
            }
        }
    }
}
