using ConsoleTables;
using Super_Market_Management_System.Common.Enums;
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
        private static ProductService productService = new();
        #region Product
        public static void MenuProducts ()
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


