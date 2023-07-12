using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.SalesService
{
    public class SalesService
    {

        public List<SalesItem> SalesItems;
        public List<Sale> Sales;

        public SalesService()
        {
            SalesItems = new();
            Sales = new();
        }





        //public void RemoveProductByName(string name )
        //{
        //    var existingProduct = Products.FirstOrDefault(x => x.Name == name);

        //    if (existingProduct == null)
        //        throw new Exception($"{name} not found!");
        //    Products = Products.Where(x => x.Name != name).ToList();
        //}
        //public void RemoveProductByPrice (decimal price)
        //{
        //    var existingProduct = Products.FirstOrDefault(x=>x.Price == price);
        //    if (existingProduct == null)
        //        throw new Exception($"{price} not found!");
        //    Products = Products.Where (x => x.Price != price).ToList();
        //}

        //public void RemoveProductByCategory(Category category)
        //{
        //    var existingProduct = Products.FirstOrDefault(x => x.Category == category);
        //    if (existingProduct == null)
        //        throw new Exception($"{category} not found!");
        //    Products = Products.Where(x => x.Category != category).ToList();
        //}

       
        //public void UpdateProductQuantity(string name, int Id, int quantity)
        //{
        //    var existingProduct = Products.FirstOrDefault(x => x.Id == Id);
        //    if (existingProduct == null)
        //        throw new Exception($"{Id} not found!");
        //    Console.WriteLine($"Current quantity of product {Id}: {existingProduct.Quantity}");
        //    Console.WriteLine("Enter the new quantity:");

        //    if (!int.TryParse(Console.ReadLine(), out int newQuantity))
        //    {
        //        Console.WriteLine("Invalid quantity input!");
        //        return;
        //    }

        //    existingProduct.Quantity = newQuantity;
        //    Console.WriteLine($"Quantity for product {Id} updated to {newQuantity}.");
        //}
       

            //Console.WriteLine("Enter the new name:");
            //string newName = Console.ReadLine();

            //Console.WriteLine("Enter the new quantity:");
            //int newQuantity = int.Parse(Console.ReadLine());

            //Console.WriteLine("Available categories:");
            //foreach (Category category in Enum.GetValues(typeof(Category)))
            //{
            //    Console.WriteLine($"{(int)category}. {category}");
            //}
            //Console.WriteLine("Enter the category (number) of the new product:");
            //int categoryNumber = int.Parse(Console.ReadLine());

            //if (!Enum.IsDefined(typeof(Category), categoryNumber))
            //{
            //    Console.WriteLine("Invalid category number!");
            //    return;
            //}
            //Category newCategory = (Category)categoryNumber;

            //Console.WriteLine("Enter the new price:");
            //decimal newPrice = decimal.Parse(Console.ReadLine());
         
        //public static void MenuProducts() 
        //{
        //    try
        //    {
        //        var products = hospitalService.GetDoctors();

        //        var table = new ConsoleTable("Id", "Name", "Category",
        //            "Price", "Quantity");

        //        if (products.Quantity == 0)
        //        {
        //            Console.WriteLine("No products yet.");
        //            return;
        //        }

        //        foreach (var product in products)
        //        {
        //            table.AddRow(product.Id, product.Name, product.Cateory,
        //                product.Price, product.Quantity);
        //        }

        //        table.Write();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Oops! Got an error!");
        //        Console.WriteLine(ex.Message);
        //    }
        //}
           
        }
    }

        
        


