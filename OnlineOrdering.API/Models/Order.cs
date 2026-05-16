namespace OnlineOrdering.API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }

        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public DiningTable? DiningTable { get; set; }

        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; } = 0.00m;
        public int? DeliveryZoneId { get; set; }
        public DeliveryZone? DeliveryZone { get; set; }
        public string? DeliveryRegion { get; set; }
        public string OrderType { get; set; } = "DineIn";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public bool IsDeleted { get; set; } = false;
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
    }
}
