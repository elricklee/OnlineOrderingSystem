using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class DiningTableDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tableNumber")]
        public string TableNumber { get; set; } = "";

        [JsonProperty("seatCount")]
        public int SeatCount { get; set; }

        [JsonProperty("isOccupied")]
        public bool IsOccupied { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
    }
}
