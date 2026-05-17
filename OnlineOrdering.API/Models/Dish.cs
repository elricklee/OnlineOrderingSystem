namespace OnlineOrdering.API.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public DishCategory? CategoryEntity { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int SpicyLevel { get; set; } = 0;
        public bool IsAvailable { get; set; } = true;
        public string? Description { get; set; }
        public string SaleStatus { get; set; } = DishSaleStatuses.OnSale;
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public int? DeletedByUserId { get; set; }
        public string? DeleteReason { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
