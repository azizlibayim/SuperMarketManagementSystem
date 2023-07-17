using Super_Market_Management_System.Common.Base;
using Super_Market_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Common.Models
{
    public class Sale:BaseEntity
    {
        private static int _count = 1000;
        public Sale()
        {Date = DateTime.Now;
         SalesItems = new List<SalesItems>();
            Id = _count;
            _count++;
        }
        Product Product { get; set; }
        public decimal TotalAmount { get; set; }
        public List <SalesItems> SalesItems { get; set; }
        public DateTime Date { get; set;}
    }
}
