using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class RecommendationRequestDto
    {
        [JsonProperty("currentItems")]
        public List<CurrentItemDto> CurrentItems { get; set; } = new();

        [JsonProperty("preferences")]
        public string Preferences { get; set; } = "";
    }

    public class CurrentItemDto
    {
        [JsonProperty("dishId")]
        public int DishId { get; set; }

        [JsonProperty("dishName")]
        public string DishName { get; set; } = "";
    }

    public class RecommendationResponseDto
    {
        [JsonProperty("recommendations")]
        public List<RecommendationItemDto> Recommendations { get; set; } = new();
    }

    public class RecommendationItemDto
    {
        [JsonProperty("dishId")]
        public int DishId { get; set; }

        [JsonProperty("dishName")]
        public string DishName { get; set; } = "";

        [JsonProperty("reason")]
        public string Reason { get; set; } = "";
    }
}
