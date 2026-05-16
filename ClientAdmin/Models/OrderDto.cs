namespace ClientAdmin.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public string? OrderType { get; set; }
        public string? TableNumber { get; set; }
        public string? Note { get; set; }
        public decimal DeliveryFee { get; set; }
        public int? DiningTableId { get; set; }
        public int? DeliveryZoneId { get; set; }
        public string? DeliveryRegion { get; set; }
    }
}
