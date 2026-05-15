namespace OnlineOrdering.API.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        public int SpicyLevel { get; set; } = 0;

        public bool IsAvailable { get; set; } = true;

        public string? Description { get; set; }

        //Âß¼­É¾³ý×Ö¶Î
        public bool IsDeleted { get; set; } = false;
    }
}