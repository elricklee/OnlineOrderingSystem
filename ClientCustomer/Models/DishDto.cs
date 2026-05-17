using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class DishDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; } = "";

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("imagePath")]
        public string? ImagePath { get; set; }

        [JsonProperty("spicyLevel")]
        public int SpicyLevel { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; } = true;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("saleStatus")]
        public string SaleStatus { get; set; } = "OnSale";
    }
}
