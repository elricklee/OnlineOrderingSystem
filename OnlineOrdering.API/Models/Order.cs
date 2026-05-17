namespace OnlineOrdering.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public DiningTable? DiningTable { get; set; }
        public int? TableSessionId { get; set; }
        public TableSession? TableSession { get; set; }
        public int? DinerCount { get; set; }
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; } = 0.00m;
        public int? DeliveryZoneId { get; set; }
        public DeliveryZone? DeliveryZone { get; set; }
        public string? DeliveryRegion { get; set; }
        public string OrderType { get; set; } = OrderTypes.DineIn;
        public string Status { get; set; } = OrderStatuses.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public bool IsDeleted { get; set; } = false;
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
        public List<OrderStatusHistory> StatusHistories { get; set; } = new();
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? DishCategorySnapshot { get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
        public Dish? Dish { get; set; }
    }
}
