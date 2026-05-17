using System.ComponentModel.DataAnnotations;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int SpicyLevel { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
        public string SaleStatus { get; set; } = DishSaleStatuses.OnSale;
        public int SortOrder { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeleteReason { get; set; }
    }

    public class DishCreateUpdateDto
    {
        [Required(ErrorMessage = "菜品名称不能为空")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "菜品分类不能为空")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "价格不能为空")]
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        [Range(0, 3)]
        public int SpicyLevel { get; set; }

        public bool IsAvailable { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }

        [RegularExpression("OnSale|OffSale|OutOfStock")]
        public string SaleStatus { get; set; } = DishSaleStatuses.OnSale;

        [Range(0, 9999)]
        public int SortOrder { get; set; }
    }

    public class DishDeleteDto
    {
        [StringLength(200)]
        public string? DeleteReason { get; set; }
    }

    public class DishSaleStatusUpdateDto
    {
        [Required]
        [RegularExpression("OnSale|OffSale|OutOfStock")]
        public string SaleStatus { get; set; } = DishSaleStatuses.OnSale;
    }

    public class DishCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }
    }
}
