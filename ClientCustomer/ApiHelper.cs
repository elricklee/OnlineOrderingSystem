using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClientCustomer.Models;

namespace ClientCustomer
{
    public static class ApiHelper
    {
        private static readonly HttpClient _client;

        static ApiHelper()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/"),
                Timeout = TimeSpan.FromSeconds(30)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient Client => _client;

        // 获取所有菜品
        public static async Task<List<DishDto>> GetDishesAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/dishes");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DishDto>>(json) ?? new List<DishDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"获取菜品失败: {ex.Message}");
            }
        }

        // 创建订单
        public static async Task<OrderDto> CreateOrderAsync(OrderCreateDto order)
        {
            try
            {
                var json = JsonConvert.SerializeObject(order);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/orders", content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OrderDto>(result)
                    ?? throw new Exception("订单创建失败");
            }
            catch (Exception ex)
            {
                throw new Exception($"创建订单失败: {ex.Message}");
            }
        }

        // 获取订单详情
        public static async Task<OrderDto> GetOrderAsync(int orderId)
        {
            try
            {
                var response = await _client.GetAsync($"api/orders/{orderId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OrderDto>(json)
                    ?? throw new Exception("订单不存在");
            }
            catch (Exception ex)
            {
                throw new Exception($"获取订单失败: {ex.Message}");
            }
        }

        // 获取AI推荐
        public static async Task<RecommendationResponseDto> GetRecommendationAsync(
            RecommendationRequestDto request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/ai/recommend", content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RecommendationResponseDto>(result)
                    ?? new RecommendationResponseDto();
            }
            catch (Exception ex)
            {
                // AI推荐失败时返回空结果,不影响主流程
                return new RecommendationResponseDto();
            }
        }
    }
}