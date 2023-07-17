using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.SalesServices
{
    public class SalesService
    {
        private static List<Sale> Sales = new List<Sale>();
        private static List<SalesItems> SaleItems = new List<SalesItems>();
        private static List<Product> Products = new List<Product>();
        public SalesService()
        {
            SaleItems = new();
            Sales = new();
            Products = new();
        }

        public static List<SalesItems> ShowAllSaleItems()
        {
            return SaleItems;
        }
        public static List<SalesItems > ShowTheBill() 
        {
            return SaleItems;
        }
        public static void AddSaleItem(Product product, int count)
        {
            SaleItems.Add(new SalesItems { Product = product, Count = count });
        }
        public static void CalculateTotalAmount()
        {
            decimal TotalAmount = 0;
            foreach (var item in SaleItems)
            {
                TotalAmount += item.Product.Price * item.Count;
            }
        }
        public static List <Sale> ShowAllSales() 
        {
            return Sales;
        }
        public static int AddSale(int productId, int count)
        {
            if (productId < 0)
                throw new Exception("Product not found!");

            if (count < 0)
                throw new FormatException("Quantity is invalid!");

            var existingProduct = Products.FirstOrDefault(x => x.Id == productId);

            if (existingProduct == null)
            {
                existingProduct = new Product
                {
                    Id = productId
                };
                Products.Add(existingProduct);
            }

            existingProduct.Quantity -= count;

            var newSalesItem = new SalesItems
            {
                Count = count,
                Product = existingProduct
            };

            SaleItems.Add(newSalesItem);
            
            var newSale = new Sale
            {
                Date = DateTime.Now,
                SalesItems = new List<SalesItems> { newSalesItem }
            };
            Sales.Add(newSale);

            return newSale.Id;
        }
        public static void RemoveSaleById(int Id)
        {
            var existingSale = Sales.FirstOrDefault(x => x.Id == Id);
            if (existingSale == null)
                throw new Exception($"{Id} not found!");
            Sales = Sales.Where(x => x.Id != Id).ToList();
            Sales.Remove(existingSale);

        }
        public static List<Sale> ShowSalesByPeriod(DateTime start, DateTime end)
        {
            var salesInPeriod = Sales.Where(x => x.Date >= start && x.Date <= end).ToList();
            return salesInPeriod;
        }
        public static List<Sale> ShowSalesByDate(DateTime date)
        {
            var sales = Sales.Where(sale => sale.Date.Date == date.Date).ToList();
            if (sales.Count == 0)
                throw new Exception("Sales not found!");

            return sales;
        }

    }
}

            
         
    
        
        


