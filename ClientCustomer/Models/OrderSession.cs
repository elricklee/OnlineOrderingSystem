namespace ClientCustomer.Models
{
    public class OrderSession
    {
        public string OrderType { get; set; } = "DineIn";
        public string? TableNumber { get; set; }
        public int? DiningTableId { get; set; }
        public int? DinerCount { get; set; }
        public string? Phone { get; set; }
        public int? DeliveryZoneId { get; set; }
        public string? DeliveryRegion { get; set; }
        public string? DeliveryAddressDetail { get; set; }
        public decimal DeliveryFee { get; set; }

        public string? FullDeliveryAddress
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DeliveryRegion) && string.IsNullOrWhiteSpace(DeliveryAddressDetail))
                {
                    return null;
                }

                return string.Join(" ", new[] { DeliveryRegion, DeliveryAddressDetail }.Where(x => !string.IsNullOrWhiteSpace(x)));
            }
        }
    }
}
