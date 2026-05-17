namespace ClientAdmin.Models
{
    public class DeliveryZoneDto
    {
        public int Id { get; set; }
        public string Province { get; set; } = "";
        public string City { get; set; } = "";
        public string District { get; set; } = "";
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public string DisplayName { get; set; } = "";
        public bool IsDeleted { get; set; }
    }

    public class DeliveryZoneCreateUpdateDto
    {
        public string Province { get; set; } = "";
        public string City { get; set; } = "";
        public string District { get; set; } = "";
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; }
    }
}
