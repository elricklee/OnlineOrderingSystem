using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int? DishId { get; set; }

        public string DishName { get; set; } = "";

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal => Price * Quantity;
    }
}
