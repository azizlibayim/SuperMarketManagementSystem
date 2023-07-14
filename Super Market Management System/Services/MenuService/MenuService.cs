using ConsoleTables;
using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.MenuService
{
    public class MenuService 
    {
        private  static ProductService productService = new();
        #region Product
        public static void MenuShowAllProducts()
        {
            try
            {
                var products = productService.ShowAllProducts();
                var table = new ConsoleTable("Id", "Name", "Category",
                    "Price", "Quantity");
                if (products.Quantity == 0)
                {
                    Console.WriteLine("No products yet.");
                    return;
                }
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                    table.Write();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuAddProduct ()
        {
            try
            {
                Console.WriteLine("Enter product`s name:");
                string name = Console.ReadLine();
                Console.WriteLine( "Enter product`s category:");
                string category = Console.ReadLine();
                Console.WriteLine("Enter product`s price:");
                decimal price = int.Parse (Console.ReadLine());
                Console.WriteLine("Enter product`s quantity:");
                int quantity = int.Parse(Console.ReadLine());
                int productId = productService.AddProduct(name, category, price, quantity);

                Console.WriteLine($"Added product with ID: {productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRemoveProductById()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int productId = int.Parse(Console.ReadLine());

                productService.RemoveProductById(productId);

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
                productService.UpdateProductById(Id, newName, newQuantity, newCategory, newPrice);

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

                if (!Enum.IsDefined(typeof(Category), categoryNumber))
                {
                    Console.WriteLine("Invalid category number!");
                    return;
                }
                var products = productService.ShowProductsByCategory();
                var table = new ConsoleTable("Id", "Name", "Category", "Price", "Quantity");
                foreach (var product in products) 
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

    }
    //{
    //    public static void ShowProductsByCategory()
    //    {
    //        // Display logic
    //        Console.WriteLine("Available categories:");
    //        foreach (Category category in Enum.GetValues(typeof(Category)))
    //        {
    //            Console.WriteLine($"{(int)category}. {category}");
    //        }

    //        Console.WriteLine("Enter the category (number) to show products:");
    //        int categoryNumber = int.Parse(Console.ReadLine());

    //        // Call the implementation in the second service
    //        ShowProductsByCategory(categoryNumber);
    //    }
}


