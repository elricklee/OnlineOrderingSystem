namespace ClientAdmin.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int SpicyLevel { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? Description { get; set; }
    }
}
