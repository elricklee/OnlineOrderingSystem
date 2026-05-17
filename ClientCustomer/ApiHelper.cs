using ClientCustomer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ClientCustomer
{
    public static class ApiHelper
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("http://127.0.0.1:5000/"),
            Timeout = TimeSpan.FromSeconds(30)
        };

        private static void ApplyClientHeaders()
        {
            _client.DefaultRequestHeaders.Remove("X-Client-Role");
            _client.DefaultRequestHeaders.Remove("X-User-Id");

            if (Program.CurrentUser != null)
            {
                _client.DefaultRequestHeaders.Add("X-Client-Role", "Customer");
                _client.DefaultRequestHeaders.Add("X-User-Id", Program.CurrentUser.Id.ToString());
                return;
            }

            if (Program.IsGuestMode)
            {
                _client.DefaultRequestHeaders.Add("X-Client-Role", "Guest");
            }
        }

        public static async Task<List<DishDto>> GetDishesAsync()
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync("api/dishes/available");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DishDto>>(json) ?? new List<DishDto>();
        }

        public static async Task<List<DeliveryZoneDto>> GetDeliveryZonesAsync()
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync("api/deliveryzones/active");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DeliveryZoneDto>>(json) ?? new List<DeliveryZoneDto>();
        }

        public static async Task<List<DiningTableDto>> GetAvailableTablesAsync()
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync("api/diningtables/available");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DiningTableDto>>(json) ?? new List<DiningTableDto>();
        }

        public static async Task<OrderDto> CreateOrderAsync(OrderCreateDto orderCreate)
        {
            ApplyClientHeaders();
            var json = JsonConvert.SerializeObject(orderCreate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/orders", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                try
                {
                    var errorObj = JObject.Parse(errorJson);
                    var message = errorObj["message"]?.ToString() ?? $"服务器错误({(int)response.StatusCode})";
                    throw new Exception(message);
                }
                catch (JsonException)
                {
                    throw new Exception($"服务器错误({(int)response.StatusCode})");
                }
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrderDto>(responseJson)
                ?? throw new Exception("订单创建返回数据异常");
        }

        public static async Task<OrderDto> GetOrderAsync(int orderId)
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync($"api/orders/{orderId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OrderDto>(json)
                ?? throw new Exception("订单查询返回数据异常");
        }

        public static async Task<TableSessionDto?> GetCurrentTableSessionAsync(int diningTableId)
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync($"api/diningtables/{diningTableId}/sessions/current");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TableSessionDto>(json);
        }

        public static async Task<RecommendationResponseDto> GetRecommendationAsync(RecommendationRequestDto request)
        {
            ApplyClientHeaders();
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
            ApplyClientHeaders();
            var request = new LoginRequest { Username = username, Password = password };
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/login", content);

            var responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorObj = JObject.Parse(responseJson);
                    var message = errorObj["message"]?.ToString() ?? $"登录失败({(int)response.StatusCode})";
                    return new LoginResponse { Success = false, Message = message };
                }
                catch
                {
                    return new LoginResponse { Success = false, Message = $"登录失败({(int)response.StatusCode})" };
                }
            }

            return JsonConvert.DeserializeObject<LoginResponse>(responseJson) ?? new LoginResponse { Success = false, Message = "登录失败" };
        }

        public static async Task<LoginResponse> RegisterAsync(RegisterRequest request)
        {
            ApplyClientHeaders();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/register", content);

            var responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorObj = JObject.Parse(responseJson);
                    var message = errorObj["message"]?.ToString() ?? $"注册失败({(int)response.StatusCode})";
                    return new LoginResponse { Success = false, Message = message };
                }
                catch
                {
                    return new LoginResponse { Success = false, Message = $"注册失败({(int)response.StatusCode})" };
                }
            }

            return JsonConvert.DeserializeObject<LoginResponse>(responseJson) ?? new LoginResponse { Success = false, Message = "注册失败" };
        }

        public static async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            ApplyClientHeaders();
            var response = await _client.GetAsync($"api/orders/user/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderDto>>(json) ?? new List<OrderDto>();
        }

        public static async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordRequest request)
        {
            ApplyClientHeaders();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/change-password", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, "密码修改成功");
            }

            return (false, ExtractErrorMessage(responseJson, response.StatusCode, "修改密码失败"));
        }

        public static async Task<(bool Success, string Message)> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            ApplyClientHeaders();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/users/forgot-password", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, "密码重设成功");
            }

            return (false, ExtractErrorMessage(responseJson, response.StatusCode, "找回密码失败"));
        }

        private static string ExtractErrorMessage(string responseJson, System.Net.HttpStatusCode statusCode, string fallback)
        {
            try
            {
                var errorObj = JObject.Parse(responseJson);
                return errorObj["message"]?.ToString() ?? $"{fallback}({(int)statusCode})";
            }
            catch
            {
                return $"{fallback}({(int)statusCode})";
            }
        }
    }
}
