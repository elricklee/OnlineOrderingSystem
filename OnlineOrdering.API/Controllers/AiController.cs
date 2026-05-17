using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers
{
    [Route("api/ai")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet("suggest-operation")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetOperationSuggestions([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int topCount = 5)
        {
            try
            {
                var result = await _aiService.GetOperationSuggestionsAsync(startDate, endDate, topCount);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取运营建议失败：{ex.Message}" });
            }
        }

        [HttpPost("suggest-operation")]
        [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
        public async Task<IActionResult> GetOperationSuggestions([FromBody] AiOperationSuggestRequestDto dto)
        {
            try
            {
                var result = await _aiService.GetOperationSuggestionsAsync(dto.StartDate, dto.EndDate, dto.TopCount);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取运营建议失败：{ex.Message}" });
            }
        }

        //菜品推荐接口
        [HttpPost("recommend-dish")]
        public async Task<IActionResult> GetDishRecommendations([FromBody] AiRecommendRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _aiService.GetDishRecommendationsAsync(request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"获取菜品推荐失败：{ex.Message}" });
            }
        }
    }
}
