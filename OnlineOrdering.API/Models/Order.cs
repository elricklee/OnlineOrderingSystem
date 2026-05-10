namespace OnlineOrdering.API.Models
{
    public class Order
    {
        public int Id { get; set; }//订单id

        //外卖
        public string CustomerName { get; set; } = string.Empty;//姓名
        public string Phone { get; set; } = string.Empty;//电话
        public string? Address { get; set; }//地址

        //堂食
        public string? TableNumber { get; set; }//桌号

        //通用
        public string? Note { get; set; }//备注
        public decimal TotalAmount { get; set; }//总金额
        public decimal DeliveryFee { get; set; } = 0.00m;//配送费
        public string OrderType { get; set; } = "DineIn";//订单类型：DineIn（堂食）/Delivery（外卖）
        public string Status { get; set; } = "Pending";//订单状态
        public DateTime CreatedAt { get; set; } = DateTime.Now;//创建时间
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
    }
}