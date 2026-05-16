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
        public int? UserId { get; set; }
        [Required] public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [Required] public string OrderType { get; set; } = "DineIn";
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public string? Address { get; set; }
        public int? DeliveryZoneId { get; set; }
        public string? DeliveryRegion { get; set; }
        public decimal DeliveryFee { get; set; }
        public string? Note { get; set; }
        public string? CancelReason { get; set; }

        [Required] public List<OrderItemDto> OrderItems { get; set; } = new();
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; }
        public int? DeliveryZoneId { get; set; }
        public string? DeliveryRegion { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? CancelReason { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? PreparingAt { get; set; }
        public DateTime? ReadyAt { get; set; }
        public DateTime? DeliveringAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public int EstimatedMinutes { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonPhone { get; set; }
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
        public string? CancelReason { get; set; }
    }
}
