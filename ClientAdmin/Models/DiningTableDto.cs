namespace ClientAdmin.Models
{
    public class DiningTableDto
    {
        public int Id { get; set; }
        public string TableNumber { get; set; } = "";
        public int SeatCount { get; set; }
        public int RemainingSeats { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; }
        public string Status { get; set; } = "Available";
        public int CurrentOccupiedSeats { get; set; }
    }

    public class DiningTableCreateUpdateDto
    {
        public string TableNumber { get; set; } = "";
        public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
