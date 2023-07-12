using Super_Market_Management_System.Common.Base;
using Super_Market_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Common.Models
{
    public class Product:BaseEntity
    {
        private static int _count = 0;
        
        public Product()
        {
            Id = _count;
            _count++;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
    }
}
