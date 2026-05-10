namespace ClientAdmin.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();

        // 下面这些是按软件设计文档预留的字段。
        // 目前后端如果还没返回，它们会显示为空或 0，不影响运行。
        public string? OrderType { get; set; }

        public string? TableNumber { get; set; }

        public string? Note { get; set; }

        public decimal DeliveryFee { get; set; }
    }
}