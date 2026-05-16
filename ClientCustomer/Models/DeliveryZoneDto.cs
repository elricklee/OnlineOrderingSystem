using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class DeliveryZoneDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; } = "";

        [JsonProperty("city")]
        public string City { get; set; } = "";

        [JsonProperty("district")]
        public string District { get; set; } = "";

        [JsonProperty("deliveryFee")]
        public decimal DeliveryFee { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; } = "";
    }
}
