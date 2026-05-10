using System.ComponentModel.DataAnnotations;

namespace OnlineOrdering.API.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int SpicyLevel { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
    }

    public class DishCreateUpdateDto
    {
        [Required(ErrorMessage = "菜品名称不能为空")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "菜品分类不能为空")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "价格不能为空")]
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        [Range(0, 3)]
        public int SpicyLevel { get; set; } = 0;

        public bool IsAvailable { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }
    }
}