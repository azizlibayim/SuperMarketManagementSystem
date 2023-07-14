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
       

            
         
    
        
        


