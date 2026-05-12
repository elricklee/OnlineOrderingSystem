using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class OrderCreateDto
    {
        [JsonProperty("customerName")]
        public string CustomerName { get; set; } = "";

        [JsonProperty("phone")]
        public string Phone { get; set; } = "";

        [JsonProperty("orderType")]
        public string OrderType { get; set; } = "DineIn";

        [JsonProperty("tableNumber")]
        public string? TableNumber { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("deliveryFee")]
        public decimal DeliveryFee { get; set; }

        [JsonProperty("orderItems")]
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }

    public class OrderItemDto
    {
        [JsonProperty("dishId")]
        public int DishId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
