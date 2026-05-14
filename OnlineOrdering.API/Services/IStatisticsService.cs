using OnlineOrdering.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Services
{
    public interface IStatisticsService
    {
        //TOP5热销菜品
        Task<List<TopDishDto>> GetTopDishesAsync(int count = 5);

        //营收统计
        Task<RevenueStatDto> GetRevenueStatsAsync();
    }
}