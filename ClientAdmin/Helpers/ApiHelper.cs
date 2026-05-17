using ClientAdmin.Models;
using Newtonsoft.Json;
using System.Text;

namespace ClientAdmin.Helpers
{
    public static class ApiHelper
    {
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler
        {
            UseProxy = false
        })
        {
            BaseAddress = new Uri("http://127.0.0.1:5000/")
        };

        static ApiHelper()
        {
            ApplyAdminHeaders();
        }

        private static void ApplyAdminHeaders()
        {
            client.DefaultRequestHeaders.Remove("X-Client-Role");
            client.DefaultRequestHeaders.Remove("X-User-Id");
            client.DefaultRequestHeaders.Add("X-Client-Role", "Admin");
        }

        public static async Task<List<T>> GetListAsync<T>(string url)
        {
            ApplyAdminHeaders();
            var response = await client.GetAsync(url);
            await EnsureSuccessAsync(response, url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public static async Task<T?> GetAsync<T>(string url)
        {
            ApplyAdminHeaders();
            var response = await client.GetAsync(url);
            await EnsureSuccessAsync(response, url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task PostAsync<T>(string url, T data)
        {
            ApplyAdminHeaders();
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            await EnsureSuccessAsync(response, url);
        }

        public static async Task PutAsync<T>(string url, T data)
        {
            ApplyAdminHeaders();
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            await EnsureSuccessAsync(response, url);
        }

        public static async Task DeleteAsync<T>(string url, T data)
        {
            ApplyAdminHeaders();
            var json = JsonConvert.SerializeObject(data);
            using var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
            await EnsureSuccessAsync(response, url);
        }

        public static async Task DeleteAsync(string url)
        {
            ApplyAdminHeaders();
            var response = await client.DeleteAsync(url);
            await EnsureSuccessAsync(response, url);
        }

        // 用户管理相关 API
        public static async Task<List<UserDto>> GetUsersAsync()
        {
            return await GetListAsync<UserDto>("api/users");
        }

        public static async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await GetAsync<UserDto>($"api/users/{id}");
        }

        public static async Task UpdateUserAsync(int id, UpdateUserRequest request)
        {
            await PutAsync($"api/users/{id}/status", request);
        }

        public static async Task<List<OrderStatusHistoryDto>> GetOrderStatusHistoryAsync(int orderId)
        {
            return await GetListAsync<OrderStatusHistoryDto>($"api/orders/{orderId}/status-history");
        }

        public static async Task<List<DishCategoryDto>> GetDishCategoriesAsync()
        {
            return await GetListAsync<DishCategoryDto>("api/dishcategories/enabled");
        }

        private static async Task EnsureSuccessAsync(HttpResponseMessage response, string url)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var errorText = await response.Content.ReadAsStringAsync();
            throw new Exception(
                $"请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n" +
                $"请求地址：{client.BaseAddress}{url}\n" +
                errorText);
        }
    }
}
