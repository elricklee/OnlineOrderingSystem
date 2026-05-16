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

        public static async Task<List<DeliveryZoneDto>> GetDeliveryZonesAsync()
        {
            var response = await _client.GetAsync("api/deliveryzones/active");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DeliveryZoneDto>>(json) ?? new List<DeliveryZoneDto>();
        }

        public static async Task<List<DiningTableDto>> GetAvailableTablesAsync()
        {
            var response = await _client.GetAsync("api/diningtables/available");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DiningTableDto>>(json) ?? new List<DiningTableDto>();
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

        public static async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var request = new LoginRequest { Username = username, Password = password };
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/login", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                return new LoginResponse { Success = false, Message = $"服务器错误({(int)response.StatusCode})" };
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(responseJson) ?? new LoginResponse { Success = false, Message = "登录失败" };
        }

        public static async Task<LoginResponse> RegisterAsync(RegisterRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/register", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                return new LoginResponse { Success = false, Message = $"服务器错误({(int)response.StatusCode})" };
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(responseJson) ?? new LoginResponse { Success = false, Message = "注册失败" };
        }

        public static async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var response = await _client.GetAsync($"api/orders/user/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderDto>>(json) ?? new List<OrderDto>();
        }
    }
}
