using System;
using System.Collections.Generic;

namespace ClientCustomer.Models
{
    public class RecommendationRequestDto
    {
        public List<CurrentItemDto> CurrentItems { get; set; } = new();
        public string? Preferences { get; set; }
    }

    public class CurrentItemDto
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
    }

    public class RecommendationResponseDto
    {
        public List<RecommendationItemDto> Recommendations { get; set; } = new();
    }

    public class RecommendationItemDto
    {
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}