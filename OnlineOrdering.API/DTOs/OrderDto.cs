using System.ComponentModel.DataAnnotations;

namespace OnlineOrdering.API.DTOs
{
    public class OrderItemDto
    {
        public int DishId { get; set; }

        [Range(1, 99)]
        public int Quantity { get; set; }
    }

    public class OrderCreateDto
    {
        [Required] public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [Required] public string OrderType { get; set; } = "DineIn";
        public string? TableNumber { get; set; }
        public string? Address { get; set; }
        public decimal DeliveryFee { get; set; }
        public string? Note { get; set; }

        [Required] public List<OrderItemDto> OrderItems { get; set; } = new();
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TableNumber { get; set; }
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponseDto> OrderItems { get; set; } = new();
    }

    public class OrderItemResponseDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderUpdateStatusDto
    {
        [Required] public string Status { get; set; } = string.Empty;
    }
}