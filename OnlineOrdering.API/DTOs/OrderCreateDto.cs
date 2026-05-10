namespace OnlineOrdering.API.DTOs
{
    public class OrderCreateDto
    {
        public string CustomerName { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

        public List<OrderItemCreateDto> OrderItems { get; set; } = new();
    }

    public class OrderItemCreateDto
    {
        public int DishId { get; set; }

        public int Quantity { get; set; }
    }
}