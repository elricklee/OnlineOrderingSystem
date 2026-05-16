using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class OrderDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

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

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("deliveryZoneId")]
        public int? DeliveryZoneId { get; set; }

        [JsonProperty("deliveryRegion")]
        public string? DeliveryRegion { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("deliveryFee")]
        public decimal DeliveryFee { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = "Pending";

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("orderItems")]
        public List<OrderItemDetailDto> OrderItems { get; set; } = new();
    }

    public class OrderItemDetailDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dishId")]
        public int DishId { get; set; }

        [JsonProperty("dishName")]
        public string DishName { get; set; } = "";

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
