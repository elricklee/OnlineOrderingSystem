using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
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
        public async Task<IActionResult> GetOperationSuggestions([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int topCount = 5)
        {
            var result = await _aiService.GetOperationSuggestionsAsync(startDate, endDate, topCount);
            return Ok(result);
        }

        [HttpPost("suggest-operation")]
        public async Task<IActionResult> GetOperationSuggestions([FromBody] AiOperationSuggestRequestDto dto)
        {
            var result = await _aiService.GetOperationSuggestionsAsync(dto.StartDate, dto.EndDate, dto.TopCount);
            return Ok(result);
        }
    }
}
