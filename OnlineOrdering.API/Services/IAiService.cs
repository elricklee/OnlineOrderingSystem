using OnlineOrdering.API.DTOs;

namespace OnlineOrdering.API.Services
{
    public interface IAiService
    {
        Task<AiOperationSuggestResponseDto> GetOperationSuggestionsAsync(DateTime? startDate = null, DateTime? endDate = null, int topCount = 5);
    }
}
