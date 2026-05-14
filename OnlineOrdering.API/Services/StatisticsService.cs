using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineOrdering.API.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly AppDbContext _db;

        public StatisticsService(AppDbContext db)
        {
            _db = db;
        }

        //获取热销菜品TOP N
        public async Task<List<TopDishDto>> GetTopDishesAsync(int count = 5)
        {
            return await _db.OrderItems
                .GroupBy(o => new { o.DishId, o.DishName, o.Price })
                .Select(g => new TopDishDto
                {
                    DishId = g.Key.DishId,
                    DishName = g.Key.DishName,
                    TotalQuantity = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.Price)
                })
                .OrderByDescending(t => t.TotalQuantity)
                .Take(count)
                .ToListAsync();
        }

        //营收统计
        public async Task<RevenueStatDto> GetRevenueStatsAsync()
        {
            var orders = await _db.Orders.ToListAsync();

            return new RevenueStatDto
            {
                TotalOrderCount = orders.Count,
                TotalRevenue = orders.Sum(o => o.TotalAmount),
                AverageOrderAmount = orders.Count == 0
                    ? 0
                    : orders.Sum(o => o.TotalAmount) / orders.Count
            };
        }
    }
}