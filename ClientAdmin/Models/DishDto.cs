using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Models
{
    //管理端用它接收和提交菜品数据。后面添加菜品、修改菜品、点击表格回填，都会用它。
    public class DishDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Category { get; set; } = "";

        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        public int SpicyLevel { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string? Description { get; set; }
    }
}
