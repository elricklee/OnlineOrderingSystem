using ClientCustomer.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientCustomer
{
    public static class ApiHelper
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/"),
            Timeout = TimeSpan.FromSeconds(30)
        };

        public static async Task<List<DishDto>> GetDishesAsync()
        {
            var response = await _client.GetAsync("api/dishes");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DishDto>>(json) ?? new List<DishDto>();
        }

        public static async Task<OrderDto> CreateOrderAsync(OrderCreateDto orderCreate)
        {
            var json = JsonConvert.SerializeObject(orderCreate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/orders", content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrderDto>(responseJson)
                ?? throw new Exception("订单创建返回数据异常");
        }

        public static async Task<OrderDto> GetOrderAsync(int orderId)
        {
            var response = await _client.GetAsync($"api/orders/{orderId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrderDto>(json)
                ?? throw new Exception("订单查询返回数据异常");
        }

        public static async Task<RecommendationResponseDto> GetRecommendationAsync(RecommendationRequestDto request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ai/recommend-dish", content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RecommendationResponseDto>(responseJson)
                ?? new RecommendationResponseDto { Recommendations = new List<RecommendationItemDto>() };
        }
    }
}
