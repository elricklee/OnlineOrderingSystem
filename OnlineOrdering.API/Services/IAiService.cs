using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IAiService
    {
        //经营建议方法
        Task<AiOperationSuggestResponseDto> GetOperationSuggestionsAsync(DateTime? startDate = null, DateTime? endDate = null, int topCount = 5);

        //菜品推荐方法
        Task<AiRecommendResponseDto> GetDishRecommendationsAsync(AiRecommendRequestDto request);
    }
}
