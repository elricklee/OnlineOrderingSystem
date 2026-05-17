using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
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
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
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
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin, UserRoles.Customer)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                if (!ClientRequestContext.IsAdmin(HttpContext) && ClientRequestContext.GetUserId(HttpContext) != userId)
                {
                    return StatusCode(403, new { message = "只能查看自己的订单。" });
                }

                return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取用户订单失败：{ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin, UserRoles.Customer)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound(new { message = "订单不存在" });
                }

                if (!ClientRequestContext.IsAdmin(HttpContext) && ClientRequestContext.GetUserId(HttpContext) != order.UserId)
                {
                    return StatusCode(403, new { message = "只能查看自己的订单详情。" });
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取订单详情失败：{ex.Message}" });
            }
        }

        [HttpPost]
        [RequireClientRole(UserRoles.Customer)]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            try
            {
                var userId = ClientRequestContext.GetUserId(HttpContext);
                if (userId == null)
                {
                    return StatusCode(403, new { message = "请先登录顾客账号后再下单。" });
                }

                dto.UserId = userId.Value;
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
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
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

        [HttpGet("{id}/status-history")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetStatusHistory(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound(new { message = "订单不存在" });
                }

                return Ok(await _orderService.GetStatusHistoryAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取订单状态轨迹失败：{ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public IActionResult Delete(int id)
        {
            return BadRequest(new { message = "订单不允许业务删除，请改用状态流转取消订单。" });
        }
    }
}
