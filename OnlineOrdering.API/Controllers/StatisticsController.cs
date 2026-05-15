using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Services;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Controllers
{
	[Route("api/statistics")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticsService _statisticsService;

		public StatisticsController(IStatisticsService statisticsService)
		{
			_statisticsService = statisticsService;
		}

		//获取热销菜品TOP N
		[HttpGet("top-dishes")]
		public async Task<IActionResult> GetTopDishes([FromQuery] int topCount = 5, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
		{
			if (topCount <= 0)
			{
				topCount = 5;
			}

			var result = await _statisticsService.GetTopDishesAsync(topCount, startDate, endDate);
			return Ok(result);
		}

		//获取营收统计（总订单、总收入、平均客单价）
		[HttpGet("revenue")]
		public async Task<IActionResult> GetRevenue([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
		{
			var result = await _statisticsService.GetRevenueStatsAsync(startDate, endDate);
			return Ok(result);
		}
	}
}
