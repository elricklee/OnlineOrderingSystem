namespace OnlineOrdering.API.Models
{
    public class DiningTable
    {
        public int Id { get; set; }
        public string TableNumber { get; set; } = string.Empty;
        public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string Status { get; set; } = "Available";
        public int CurrentOccupiedSeats { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
