using Newtonsoft.Json;
using System.Text;

namespace ClientAdmin.Helpers
{
    public static class ApiHelper
    {
        private static readonly HttpClient client = new HttpClient(
            new HttpClientHandler
            {
                UseProxy = false
            }
        )
        {
            BaseAddress = new Uri("http://127.0.0.1:5000/")
        };

        public static async Task<List<T>> GetListAsync<T>(string url)
        {
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n请求地址：{client.BaseAddress}{url}\n{errorText}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public static async Task PostAsync<T>(string url, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n请求地址：{client.BaseAddress}{url}\n{errorText}");
            }
        }

        public static async Task PutAsync<T>(string url, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n请求地址：{client.BaseAddress}{url}\n{errorText}");
            }
        }

        public static async Task DeleteAsync(string url)
        {
            var response = await client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new Exception($"请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n请求地址：{client.BaseAddress}{url}\n{errorText}");
            }
        }
    }
}