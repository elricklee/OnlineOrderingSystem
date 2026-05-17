using System.ComponentModel.DataAnnotations;
using OnlineOrdering.API.Models;

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
        [Required] public string OrderType { get; set; } = OrderTypes.DineIn;
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public int? TableSessionId { get; set; }
        public int? DinerCount { get; set; }
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
        public string OrderNo { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public int? TableSessionId { get; set; }
        public string? TableSessionNo { get; set; }
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
        public int? DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? DishCategorySnapshot { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderUpdateStatusDto
    {
        [Required] public string Status { get; set; } = string.Empty;
        public string? CancelReason { get; set; }
    }

    public class OrderStatusHistoryDto
    {
        public int Id { get; set; }
        public string FromStatus { get; set; } = string.Empty;
        public string ToStatus { get; set; } = string.Empty;
        public int? OperatorUserId { get; set; }
        public string OperatorRole { get; set; } = string.Empty;
        public string? Remark { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TableSessionDto
    {
        public int Id { get; set; }
        public int DiningTableId { get; set; }
        public string TableNumber { get; set; } = string.Empty;
        public string SessionNo { get; set; } = string.Empty;
        public int PartySize { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string? Remark { get; set; }
    }

    public class TableSessionCreateDto
    {
        [Required]
        public int DiningTableId { get; set; }

        [Range(1, 99)]
        public int PartySize { get; set; }

        [StringLength(200)]
        public string? Remark { get; set; }
    }

    public class TableSessionCloseDto
    {
        [StringLength(200)]
        public string? Remark { get; set; }
    }
}
