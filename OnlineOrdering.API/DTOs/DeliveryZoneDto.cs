using System.ComponentModel.DataAnnotations;

namespace OnlineOrdering.API.DTOs
{
    public class DeliveryZoneDto
    {
        public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class DeliveryZoneCreateUpdateDto
    {
        [Required] public string Province { get; set; } = string.Empty;
        [Required] public string City { get; set; } = string.Empty;
        [Required] public string District { get; set; } = string.Empty;
        [Range(0, 999)] public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; } = true;
        [Range(0, 999)] public int SortOrder { get; set; }
    }
}
