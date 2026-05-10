namespace OnlineOrdering.API.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string ImagePath { get; set; } = string.Empty;//Õº∆¨µÿ÷∑
        public int SpicyLevel { get; set; } //0≤ª¿± 1Œ¢¿± 2÷–¿± 3Ãÿ¿±
        public bool IsAvailable { get; set; } = true;// «∑Ò…œº‹
        public string Description { get; set; } = string.Empty;//√Ë ˆ
    }
}