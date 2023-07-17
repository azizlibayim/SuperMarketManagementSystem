using Super_Market_Management_System.Common.Base;
using Super_Market_Management_System.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Common.Models
{
    public class SalesItems : BaseEntity
    {
        private static int _saleItemNumber = 1;
        public SalesItems()
        {
            Id = _saleItemNumber;
            _saleItemNumber++;
        }
        public int SaleItemNumber { get; set; }
        public int Count { get; set; }
        public SalesItems(int saleItemNumber, int count, Product product)
        {
            SaleItemNumber = saleItemNumber;
            Count = count;
            Product = product;
        }

        public Product Product { get; set; }
    }
}
    



