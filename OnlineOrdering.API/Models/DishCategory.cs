namespace OnlineOrdering.API.Models;

public class DishCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool IsDeleted { get; set; }
    public List<Dish> Dishes { get; set; } = new();
}
