using Newtonsoft.Json;

namespace ClientCustomer.Models
{
    public class TableSessionDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("diningTableId")]
        public int DiningTableId { get; set; }

        [JsonProperty("tableNumber")]
        public string TableNumber { get; set; } = string.Empty;

        [JsonProperty("sessionNo")]
        public string SessionNo { get; set; } = string.Empty;

        [JsonProperty("partySize")]
        public int PartySize { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("openedAt")]
        public DateTime OpenedAt { get; set; }

        [JsonProperty("closedAt")]
        public DateTime? ClosedAt { get; set; }

        [JsonProperty("remark")]
        public string? Remark { get; set; }
    }
}
