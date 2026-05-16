namespace ClientAdmin.Models
{
    public class DiningTableDto
    {
        public int Id { get; set; }
        public string TableNumber { get; set; } = "";
        public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class DiningTableCreateUpdateDto
    {
        public string TableNumber { get; set; } = "";
        public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
