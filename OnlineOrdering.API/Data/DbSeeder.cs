using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            if (!await db.DishCategories.AnyAsync())
            {
                db.DishCategories.AddRange(
                    new DishCategory { Name = "热菜", SortOrder = 1, IsEnabled = true },
                    new DishCategory { Name = "凉菜", SortOrder = 2, IsEnabled = true },
                    new DishCategory { Name = "主食", SortOrder = 3, IsEnabled = true },
                    new DishCategory { Name = "饮品", SortOrder = 4, IsEnabled = true },
                    new DishCategory { Name = "汤类", SortOrder = 5, IsEnabled = true },
                    new DishCategory { Name = "小吃", SortOrder = 6, IsEnabled = true }
                );
                await db.SaveChangesAsync();
            }

            if (!await db.DeliveryZones.AnyAsync())
            {
                db.DeliveryZones.AddRange(
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6B66\u660C\u533A",
                        DeliveryFee = 4m,
                        SortOrder = 1,
                        IsActive = true
                    },
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6D2A\u5C71\u533A",
                        DeliveryFee = 5m,
                        SortOrder = 2,
                        IsActive = true
                    },
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6C5F\u590F\u533A",
                        DeliveryFee = 7m,
                        SortOrder = 3,
                        IsActive = true
                    }
                );
            }

            if (!await db.DiningTables.AnyAsync())
            {
                db.DiningTables.AddRange(
                    new DiningTable { TableNumber = "A01", SeatCount = 2, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available },
                    new DiningTable { TableNumber = "A02", SeatCount = 2, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available },
                    new DiningTable { TableNumber = "B01", SeatCount = 4, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available },
                    new DiningTable { TableNumber = "B02", SeatCount = 4, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available },
                    new DiningTable { TableNumber = "C01", SeatCount = 6, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available },
                    new DiningTable { TableNumber = "C02", SeatCount = 8, IsEnabled = true, IsOccupied = false, Status = DiningTableStatuses.Available }
                );
            }

            var categories = await db.DishCategories.ToListAsync();
            var uncategorizedDishes = await db.Dishes.Where(d => d.CategoryId == null && !string.IsNullOrWhiteSpace(d.Category)).ToListAsync();
            foreach (var dish in uncategorizedDishes)
            {
                var category = categories.FirstOrDefault(c => c.Name == dish.Category);
                if (category == null)
                {
                    category = new DishCategory
                    {
                        Name = dish.Category.Trim(),
                        SortOrder = categories.Count + 1,
                        IsEnabled = true
                    };
                    db.DishCategories.Add(category);
                    categories.Add(category);
                }

                dish.CategoryEntity = category;
            }

            await db.SaveChangesAsync();
        }
    }
}
