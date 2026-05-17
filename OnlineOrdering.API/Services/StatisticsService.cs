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
        public async Task<List<TopDishDto>> GetTopDishesAsync(int count = 5, DateTime? startDate = null, DateTime? endDate = null)
        {
            var normalizedCount = Math.Clamp(count, 1, 50);
            var filteredOrders = FilterOrders(_db.Orders.AsNoTracking(), startDate, endDate);

            return await _db.OrderItems
                .AsNoTracking()
                .Where(item => filteredOrders.Select(order => order.Id).Contains(item.OrderId))
                .Where(item => item.DishId.HasValue)
                .GroupBy(o => new { o.DishId, o.DishName, o.Price })
                .Select(g => new TopDishDto
                {
                    DishId = g.Key.DishId!.Value,
                    DishName = g.Key.DishName,
                    TotalQuantity = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.Quantity * x.Price)
                })
                .OrderByDescending(t => t.TotalQuantity)
                .ThenByDescending(t => t.TotalRevenue)
                .Take(normalizedCount)
                .ToListAsync();
        }

        //营收统计
        public async Task<RevenueStatDto> GetRevenueStatsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var orders = await FilterOrders(_db.Orders.AsNoTracking(), startDate, endDate).ToListAsync();

            return new RevenueStatDto
            {
                TotalOrderCount = orders.Count,
                TotalRevenue = orders.Sum(o => o.TotalAmount),
                AverageOrderAmount = orders.Count == 0
                    ? 0
                    : orders.Sum(o => o.TotalAmount) / orders.Count
            };
        }

        private IQueryable<Order> FilterOrders(IQueryable<Order> query, DateTime? startDate, DateTime? endDate)
        {
            query = query.Where(order => order.Status == OrderStatuses.Completed);

            if (startDate.HasValue)
            {
                var start = startDate.Value.Date;
                query = query.Where(order => order.CreatedAt >= start);
            }

            if (endDate.HasValue)
            {
                var endExclusive = endDate.Value.Date.AddDays(1);
                query = query.Where(order => order.CreatedAt < endExclusive);
            }

            return query;
        }
    }
}
