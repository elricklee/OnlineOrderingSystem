namespace OnlineOrdering.API.DTOs
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
    }

    public class OrderItemDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int DishId { get; set; }

        public string DishName { get; set; } = "";

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}