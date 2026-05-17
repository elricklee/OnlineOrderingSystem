namespace OnlineOrdering.API.Models
{
    public class DeliveryZone
    {
        public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedByUserId { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
