using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WT_Lab.Entities
{
    public class Asset
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int InvNumber { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        //Категория
        public Category Category { get; set; }
    }
}
