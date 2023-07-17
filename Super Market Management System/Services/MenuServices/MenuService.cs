using ConsoleTables;
using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using Super_Market_Management_System.Services.ProductServices;
using Super_Market_Management_System.Services.SalesServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Super_Market_Management_System.Services.MenuServices
{
    public class MenuService
    {

        private static ProductService productService = new();

        #region Product
        public static void MenuShowAllProducts()
        {
            try
            {
                var products = ProductService.ShowAllProducts();
                var table = new ConsoleTable("Id", "Name", "Category",
                    "Price", "Quantity");
                if (products.Count == 0)
                {
                    Console.WriteLine("No products yet.");
                    return;
                }
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                }
                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Choose a category:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }

                Console.WriteLine("Enter the category number:");
                string categoryInput = Console.ReadLine();

                if (!int.TryParse(categoryInput, out int categoryNumber) || !Enum.IsDefined(typeof(Category), categoryNumber))
                {
                    throw new InvalidDataException("Invalid category selection!");
                }

                Category parsedCategory = (Category)(object)categoryNumber;

                Console.WriteLine("Enter product's price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter product's quantity:");
                int quantity = int.Parse(Console.ReadLine());

                int productId = ProductService.AddProduct(name, quantity, categoryInput, price);
                Console.WriteLine($"Added product with ID: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops! Got an error! {ex.Message}");
            }
        }
        public static void MenuRemoveProductById()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int productId = int.Parse(Console.ReadLine());

                ProductService.RemoveProductById(productId);

                Console.WriteLine($"Successfully deleted product with ID: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuUpdateProductById()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();

                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter the category (number) of the new product:");
                int categoryNumber = int.Parse(Console.ReadLine());

                if (!Enum.IsDefined(typeof(Category), categoryNumber))
                {
                    Console.WriteLine("Invalid category number!");
                    return;
                }
                Category newCategory = (Category)categoryNumber;

                Console.WriteLine("Enter the new price:");
                decimal newPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new quantity:");
                int newQuantity = int.Parse(Console.ReadLine());
                ProductService.UpdateProductById(Id, newName, newQuantity, newCategory, newPrice);

                Console.WriteLine($"Product with ID {Id} has been updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductsByCategory()
        {
            try
            {
                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter the category number:");
                int categoryNumber = int.Parse(Console.ReadLine());

                ProductService.ShowProductsByCategory(categoryNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductsByPriceRange()
        {
            try
            {
                Console.WriteLine("Enter minimum value: ");
                decimal min = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter maximum value: ");
                decimal max = decimal.Parse(Console.ReadLine());
                ProductService.ShowProductsByPriceRange(min, max);

                var productsinrange = ProductService.ShowProductsByPriceRange(min, max);

                var table = new ConsoleTable("Id", "Name", "Category",
                    "Price", "Quantity");
                if (productsinrange.Count == 0)
                {
                    Console.WriteLine("No products yet.");
                    return;
                }
                foreach (var product in productsinrange)
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowProductByName()
        {
            try
            {
                Console.WriteLine("Enter products name: ");
                string name = Console.ReadLine();
                var existingproduct = ProductService.ShowProductByName(name);
                ProductService.ShowProductByName(name);
                var table = new ConsoleTable("Id", "Name", "Category",
                    "Price", "Quantity");

                foreach (var product in existingproduct)
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                }
                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion


        private static SalesService saleService = new SalesService();
        #region Sale
        public static void MenuShowAllSales()
        {
            try
            {
                var sales = SalesService.ShowAllSales();
                var table = new ConsoleTable("Id", "Total Amount", "Date");
                if (sales.Count == 0)
                {
                    Console.WriteLine("No sales yet.");
                    return;
                }
                foreach (var sale in sales)
                {
                    table.AddRow(sale.Id, sale.TotalAmount, sale.Date);
                }
                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }

        }
        public static void MenuShowTheBill(DateTime saleDate, List<SalesItems> saleItems) 
        {
            var table = new ConsoleTable("Date", "Product", "Count", "Total Price");
            decimal totalPrice = 0;
            foreach (var saleItem in saleItems)
            {
                decimal itemPrice = saleItem.Product.Price * saleItem.Count;
                table.AddRow(saleDate, saleItem.Product.Name, saleItem.Count, itemPrice);
                totalPrice += itemPrice;
            }
            table.Write();
            Console.WriteLine($"Total Price: {totalPrice}");
        }

        public static void MenuAddSale()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter product's ID (or enter 0 to finish):");
                    int productId = int.Parse(Console.ReadLine());

                    if (productId == 0)
                        break;

                    Console.WriteLine("Enter product's quantity:");
                    int count = int.Parse(Console.ReadLine());
                    DateTime date = DateTime.Now;
                    var salesItems = new List<SalesItems>();

                    int saleId = SalesService.AddSale(productId, count);
                    SalesService.ShowAllSaleItems();
                    
                    var items = SalesService.ShowAllSaleItems();
                    var table = new ConsoleTable("Id", "Product", "Count");
                    if (items.Count == 0)
                    {
                        Console.WriteLine("No sale items yet.");
                        return;
                    }
                    foreach (var saleItem in items)
                    {
                        string productName = saleItem.Product.Name;
                        table.AddRow(saleItem.Id, saleItem.Product.Name, saleItem.Count);
                    }
                    table.Write();
                    SalesService.ShowTheBill();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Oops! Got an error! {ex.Message}");
            }
        }
        public static void MenuRemoveSaleById()
        {
            try
            {
                Console.WriteLine("Enter sale's ID:");
                int Id = int.Parse(Console.ReadLine());

                SalesService.RemoveSaleById(Id);

                Console.WriteLine($"Successfully deleted sale with ID: {Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowSalesByPeriod()
        {
            try
            {
                Console.WriteLine("Enter start date:(mm/dd/yyyy) ");
                DateTime start = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter end date:(mm/dd/yyyy)");
                DateTime end = DateTime.Parse(Console.ReadLine());
                SalesService.ShowSalesByPeriod(start, end);

                var salesInPeriod = SalesService.ShowSalesByPeriod(start, end);
                var table = new ConsoleTable("Id", "Total Amount", "Date");
                if (salesInPeriod.Count == 0)
                {
                    Console.WriteLine("No sales yet.");
                    return;
                }
                foreach (var sale in salesInPeriod)
                {
                    table.AddRow(sale.Id, sale.TotalAmount, sale.Date);
                }
                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuShowSalesByDate()
        {
            try
            {
                Console.WriteLine("Enter the date : mm/dd/yyyy ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                SalesService.ShowSalesByDate(date);
                var salesOnDate = SalesService.ShowSalesByDate(date);
                var table = new ConsoleTable("Id", "Total Amount", "Date");
                if (salesOnDate.Count == 0)
                {
                    Console.WriteLine("No sales yet.");
                    return;
                }
                foreach (var sale in salesOnDate)
                {
                    table.AddRow(sale.Id, sale.TotalAmount, sale.Date);
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

           
    

        

            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Oops! Got an error! {ex.Message}");
            //}

        
    

#endregion