namespace ClientAdmin.Models
{
    public class TopDishStatDto
    {
        public int DishId { get; set; }

        public string DishName { get; set; } = string.Empty;

        public int TotalQuantity { get; set; }

        public decimal TotalRevenue { get; set; }
    }

    public class RevenueStatDto
    {
        public int TotalOrderCount { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal AverageOrderAmount { get; set; }
    }
}
