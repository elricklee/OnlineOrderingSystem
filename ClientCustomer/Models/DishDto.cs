using System;

namespace ClientCustomer.Models
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

        // 辣度文字描述
        public string SpicyText => SpicyLevel switch
        {
            0 => "不辣",
            1 => "微辣",
            2 => "中辣",
            3 => "特辣",
            _ => "未知"
        };
    }
}