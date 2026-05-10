using System;
using System.Collections.Generic;

namespace ClientCustomer.Models
{
    public class OrderCreateDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string OrderType { get; set; } = "DineIn"; // DineIn 或 Delivery
        public string? TableNumber { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public decimal DeliveryFee { get; set; } = 0.00m;
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }

    public class OrderItemDto
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}