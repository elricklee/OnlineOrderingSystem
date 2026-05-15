using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OnlineOrdering.API.Services
{
    public class AiService : IAiService
    {
        private const string DefaultEndpoint = "https://open.bigmodel.cn/api/paas/v4/chat/completions";
        private const string DefaultModel = "glm-4-flash-250414";

        private readonly AppDbContext _db;
        private readonly IStatisticsService _statisticsService;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AiService(
            AppDbContext db,
            IStatisticsService statisticsService,
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _db = db;
            _statisticsService = statisticsService;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        //AI菜品推荐
        public async Task<AiRecommendResponseDto> GetDishRecommendationsAsync(AiRecommendRequestDto request)
        {
            var apiKey = _configuration["ZhipuAI:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("请配置 ZhipuAI:ApiKey");

            //拿到数据库里真实的菜品
            var allDishes = await _db.Dishes.ToListAsync();
            var dishListStr = string.Join("\n", allDishes.Select(d => $"- {d.Id}：{d.Name}，{d.Description}"));

            string jsonTemplate = @"
{
  ""recommendations"": [
    {
      ""dishId"": 数字,
      ""dishName"": ""菜名"",
      ""reason"": ""推荐理由""
    }
  ]
}";

            var systemPrompt = $"""
你是餐厅智能推荐助手，根据用户已选菜品 + 口味偏好推荐菜品。
餐厅所有菜品：
{dishListStr}

规则：
1. 只推荐餐厅里真实存在的菜品
2. 必须**只返回JSON**，不要任何解释、不要Markdown、不要多余文字
3. 推荐 2~4 道菜品
4. 理由必须结合用户偏好和已选菜品搭配
5. 格式必须严格如下：
{jsonTemplate}
""";

            var userPrompt = $"已选菜品：{string.Join("、", request.CurrentItems.Select(x => x.DishName))}\n用户偏好：{request.Preferences}";

            var requestBody = new
            {
                model = DefaultModel,
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.7,
                response_format = new { type = "json_object" }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var resp = await _httpClient.PostAsync(DefaultEndpoint, content);
            var respJson = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
                throw new Exception($"AI 调用失败：{respJson}");

            var aiResult = JsonDocument.Parse(respJson).RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()!;

            Console.WriteLine("AI原始返回内容：");
            Console.WriteLine(aiResult);

            //容错解析
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AiRecommendResponseDto>(aiResult, options);
                if (result?.Recommendations != null && result.Recommendations.Any())
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("解析JSON失败：" + ex.Message);
            }

            //解析失败时，返回一个默认的非空推荐
            return new AiRecommendResponseDto
            {
                Recommendations = new List<AiRecommendationDto>
                {
                    new AiRecommendationDto
                    {
                        DishId = allDishes.FirstOrDefault()?.Id ?? 1,
                        DishName = allDishes.FirstOrDefault()?.Name ?? "招牌菜",
                        Reason = "为您推荐本店热门菜品，适配您的口味偏好"
                    }
                }
            };
        }

        //经营建议
        public async Task<AiOperationSuggestResponseDto> GetOperationSuggestionsAsync(DateTime? startDate = null, DateTime? endDate = null, int topCount = 5)
        {
            var apiKey = _configuration["ZhipuAI:ApiKey"] ?? Environment.GetEnvironmentVariable("ZHIPU_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("未配置智谱 API Key。请在 appsettings.json 的 ZhipuAI:ApiKey 中填写，或设置环境变量 ZHIPU_API_KEY。");
            }

            var endpoint = _configuration["ZhipuAI:Endpoint"];
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                endpoint = DefaultEndpoint;
            }

            var model = _configuration["ZhipuAI:Model"];
            if (string.IsNullOrWhiteSpace(model))
            {
                model = DefaultModel;
            }

            var normalizedTopCount = Math.Clamp(topCount, 1, 20);
            var revenue = await _statisticsService.GetRevenueStatsAsync(startDate, endDate);
            var topDishes = await _statisticsService.GetTopDishesAsync(normalizedTopCount, startDate, endDate);
            var lowSellingDishes = await GetLowSellingDishesAsync(startDate, endDate);
            var orderSummary = await GetOrderSummaryAsync(startDate, endDate);

            var systemPrompt = """
你是餐饮经营分析助手。你的任务是根据订单、营收、热销菜品和低销量菜品数据，给出具体、可执行、简洁清晰的经营建议。

要求：
1. 必须使用中文输出。
2. 不要编造没有提供的数据。
3. 每条建议都尽量结合给定数据。
4. 输出为 JSON，格式必须是：
{
  "suggestions": [
    "建议1",
    "建议2",
    "建议3"
  ]
}
5. suggestions 最少 3 条，最多 5 条。
6. 每条建议尽量是完整句子，避免空话套话。
""";

            var userPrompt = BuildBusinessAnalysisPrompt(
                startDate,
                endDate,
                normalizedTopCount,
                revenue,
                topDishes,
                lowSellingDishes,
                orderSummary);

            var requestBody = new
            {
                model,
                temperature = 0.5,
                max_tokens = 1024,
                response_format = new { type = "json_object" },
                messages = new object[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                }
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            using var response = await _httpClient.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"智谱 AI 请求失败：{(int)response.StatusCode} {response.ReasonPhrase}\n{responseText}");
            }

            var aiResponse = JsonSerializer.Deserialize<ZhipuChatResponse>(responseText, JsonOptions());
            var content = aiResponse?.Choices?.FirstOrDefault()?.Message?.Content;

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException("智谱 AI 返回内容为空。");
            }

            var parsed = ParseAiSuggestionContent(content);
            if (parsed.Suggestions.Count == 0)
            {
                throw new InvalidOperationException("智谱 AI 返回了结果，但未能解析出经营建议。");
            }

            return parsed;
        }

        private async Task<List<DishSalesSummary>> GetLowSellingDishesAsync(DateTime? startDate, DateTime? endDate)
        {
            var filteredOrders = FilterOrders(_db.Orders.AsNoTracking(), startDate, endDate);
            var orderIds = filteredOrders.Select(order => order.Id);

            return await _db.Dishes
                .AsNoTracking()
                .Select(dish => new DishSalesSummary
                {
                    Name = dish.Name,
                    TotalQuantity = _db.OrderItems
                        .Where(item => item.DishId == dish.Id && orderIds.Contains(item.OrderId))
                        .Select(item => (int?)item.Quantity)
                        .Sum() ?? 0
                })
                .OrderBy(summary => summary.TotalQuantity)
                .ThenBy(summary => summary.Name)
                .Take(3)
                .ToListAsync();
        }

        private async Task<OrderBusinessSummary> GetOrderSummaryAsync(DateTime? startDate, DateTime? endDate)
        {
            var orders = await FilterOrders(_db.Orders.AsNoTracking(), startDate, endDate).ToListAsync();

            return new OrderBusinessSummary
            {
                TotalOrders = orders.Count,
                DineInOrders = orders.Count(order => string.Equals(order.OrderType, "DineIn", StringComparison.OrdinalIgnoreCase)),
                DeliveryOrders = orders.Count(order => string.Equals(order.OrderType, "Delivery", StringComparison.OrdinalIgnoreCase))
            };
        }

        private static AiOperationSuggestResponseDto ParseAiSuggestionContent(string content)
        {
            try
            {
                var parsed = JsonSerializer.Deserialize<AiOperationSuggestResponseDto>(content, JsonOptions());
                if (parsed != null)
                {
                    parsed.Suggestions = parsed.Suggestions
                        .Where(item => !string.IsNullOrWhiteSpace(item))
                        .Select(item => item.Trim())
                        .ToList();
                    return parsed;
                }
            }
            catch
            {
                // Ignore and try plain text fallback.
            }

            var fallbackSuggestions = content
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().TrimStart('-', '•', '1', '2', '3', '4', '5', '.', '、'))
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            return new AiOperationSuggestResponseDto
            {
                Suggestions = fallbackSuggestions
            };
        }

        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        private static string BuildBusinessAnalysisPrompt(
            DateTime? startDate,
            DateTime? endDate,
            int topCount,
            RevenueStatDto revenue,
            List<TopDishDto> topDishes,
            List<DishSalesSummary> lowSellingDishes,
            OrderBusinessSummary orderSummary)
        {
            var topDishText = topDishes.Count == 0
                ? "无热销菜品数据。"
                : string.Join(
                    "\n",
                    topDishes.Select((dish, index) =>
                        $"{index + 1}. {dish.DishName}，销量 {dish.TotalQuantity}，销售额 {dish.TotalRevenue:0.00} 元"));

            var lowDishText = lowSellingDishes.Count == 0
                ? "无低销量菜品数据。"
                : string.Join(
                    "\n",
                    lowSellingDishes.Select((dish, index) =>
                        $"{index + 1}. {dish.Name}，销量 {dish.TotalQuantity}"));

            var rangeText = $"{(startDate?.ToString("yyyy-MM-dd") ?? "不限")} 至 {(endDate?.ToString("yyyy-MM-dd") ?? "不限")}";

            return $"""
请根据下面的餐厅经营统计数据，生成 3 到 5 条“可执行”的经营建议。

统计区间：{rangeText}
热销菜品统计数量：前 {topCount} 条

营收数据：
- 总订单数：{revenue.TotalOrderCount}
- 总销售额：{revenue.TotalRevenue:0.00} 元
- 平均客单价：{revenue.AverageOrderAmount:0.00} 元

订单结构：
- 堂食订单：{orderSummary.DineInOrders}
- 外卖订单：{orderSummary.DeliveryOrders}

热销菜品：
{topDishText}

低销量菜品：
{lowDishText}

请重点关注：
1. 热销菜品是否值得加大曝光或做组合销售；
2. 低销量菜品是否应该优化、促销或下架观察；
3. 客单价是否需要通过套餐、加价购等方式提高；
4. 堂食/外卖占比是否提示经营侧重点不同。
""";
        }

        private IQueryable<Order> FilterOrders(IQueryable<Order> query, DateTime? startDate, DateTime? endDate)
        {
            query = query.Where(order => order.Status != "Cancelled");

            if (startDate.HasValue)
            {
                var start = startDate.Value.Date;
                query = query.Where(order => order.CreatedAt >= start);
            }

            if (endDate.HasValue)
            {
                var endExclusive = endDate.Value.Date.AddDays(1);
                query = query.Where(order => order.CreatedAt < endExclusive);
            }

            return query;
        }

        private sealed class DishSalesSummary
        {
            public string Name { get; set; } = string.Empty;

            public int TotalQuantity { get; set; }
        }

        private sealed class OrderBusinessSummary
        {
            public int TotalOrders { get; set; }

            public int DineInOrders { get; set; }

            public int DeliveryOrders { get; set; }
        }

        private sealed class ZhipuChatResponse
        {
            public List<ZhipuChoice>? Choices { get; set; }
        }

        private sealed class ZhipuChoice
        {
            public ZhipuMessage? Message { get; set; }
        }

        private sealed class ZhipuMessage
        {
            public string? Content { get; set; }
        }
    }
}
