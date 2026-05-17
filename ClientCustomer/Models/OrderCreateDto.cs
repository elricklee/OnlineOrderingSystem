using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class OrderCreateDto
    {
        [JsonProperty("userId")]
        public int? UserId { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; } = "";

        [JsonProperty("phone")]
        public string Phone { get; set; } = "";

        [JsonProperty("orderType")]
        public string OrderType { get; set; } = "DineIn";

        [JsonProperty("tableNumber")]
        public string? TableNumber { get; set; }

        [JsonProperty("diningTableId")]
        public int? DiningTableId { get; set; }

        [JsonProperty("tableSessionId")]
        public int? TableSessionId { get; set; }

        [JsonProperty("dinerCount")]
        public int? DinerCount { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("deliveryZoneId")]
        public int? DeliveryZoneId { get; set; }

        [JsonProperty("deliveryRegion")]
        public string? DeliveryRegion { get; set; }

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
