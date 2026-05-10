using System;
using System.Collections.Generic;

namespace ClientCustomer.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? TableNumber { get; set; }
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; }
        public string OrderType { get; set; } = "DineIn";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
        public List<OrderDetailDto> OrderItems { get; set; } = new();
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}