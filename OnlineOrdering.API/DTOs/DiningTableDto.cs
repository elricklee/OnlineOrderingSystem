using System.ComponentModel.DataAnnotations;

namespace OnlineOrdering.API.DTOs
{
    public class DiningTableDto
    {
        public int Id { get; set; }
        public string TableNumber { get; set; } = string.Empty;
        public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class DiningTableCreateUpdateDto
    {
        [Required] public string TableNumber { get; set; } = string.Empty;
        [Range(1, 20)] public int SeatCount { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
