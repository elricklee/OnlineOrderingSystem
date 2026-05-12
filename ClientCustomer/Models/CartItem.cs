namespace ClientCustomer.Models
{
    public class CartItem
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => Price * Quantity;
    }
}
