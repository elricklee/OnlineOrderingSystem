namespace OnlineOrdering.API.DTOs
{
    //定义统计接口要返回的数据格式
    //热销菜品要返回什么
    public class TopDishDto
    {
        public int DishId { get; set; }//菜品id
        public string DishName { get; set; } = string.Empty;//名字
        public int TotalQuantity { get; set; }//总量（卖了多少）
        public decimal TotalRevenue { get; set; }//总收入
    }

    //营收统计要返回什么
    public class RevenueStatDto
    {
        public int TotalOrderCount { get; set; }//总订单数
        public decimal TotalRevenue { get; set; }//总收入
        public decimal AverageOrderAmount { get; set; }//平均每单收入
    }
}