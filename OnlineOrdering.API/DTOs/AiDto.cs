namespace OnlineOrdering.API.DTOs
{
    public class AiRecommendRequestDto
    {
        public List<AiCurrentItemDto> CurrentItems { get; set; } = new();
        public string? Preferences { get; set; }
    }

    public class AiCurrentItemDto
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
    }

    public class AiRecommendResponseDto
    {
        public List<AiRecommendationDto> Recommendations { get; set; } = new();
    }

    public class AiRecommendationDto
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }

    public class AiOperationSuggestRequestDto
    {
        public object? SalesData { get; set; }
    }

    public class AiOperationSuggestResponseDto
    {
        public List<string> Suggestions { get; set; } = new();
    }
}