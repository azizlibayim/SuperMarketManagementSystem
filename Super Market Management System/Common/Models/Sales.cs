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
        private static int _count = 0;
        public Sale()
        {
            Id = _count;
            _count++;
        }
        public decimal TotalAmount { get; set; }
        public string Items { get; set; }
        public DateTime Date { get; set;}
    }
}
