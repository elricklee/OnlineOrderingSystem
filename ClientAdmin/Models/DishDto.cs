namespace ClientAdmin.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int? CategoryId { get; set; }
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int SpicyLevel { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? Description { get; set; }
        public string SaleStatus { get; set; } = "OnSale";
        public int SortOrder { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeleteReason { get; set; }
    }

    public class DishDeleteDto
    {
        public string? DeleteReason { get; set; }
    }

    public class DishSaleStatusUpdateDto
    {
        public string SaleStatus { get; set; } = "OnSale";
    }

    public class DishCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }
    }
}
