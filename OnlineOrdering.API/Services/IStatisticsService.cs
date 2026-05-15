using OnlineOrdering.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Services
{
    public interface IStatisticsService
    {
        //TOP N热销菜品，支持按日期范围筛选
        Task<List<TopDishDto>> GetTopDishesAsync(int count = 5, DateTime? startDate = null, DateTime? endDate = null);

        //营收统计，支持按日期范围筛选
        Task<RevenueStatDto> GetRevenueStatsAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}
