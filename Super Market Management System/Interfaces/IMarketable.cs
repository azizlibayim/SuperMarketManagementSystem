using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Interfaces
{
    public interface IMarketable
    {
        public  void Products();
        public void Sales();
        public void AddSale();
        public void DeleteProduct();
        public void DeleteSale();
        public void DeleteByDate();
        public void DeleteByPeriod();
        public void DeleteByPayment();
        public void DeleteById();
        public void AddProduct();
        public void UpdateProductName();
        public void UpdateProductQuantity();
        public void UpdateProductPrice();
        public void UpdateProductCategory();
        public void RemoveProductByCategory();
        public void RemoveProductByPrice();
        public void RemoveProductByName();
    }
}
