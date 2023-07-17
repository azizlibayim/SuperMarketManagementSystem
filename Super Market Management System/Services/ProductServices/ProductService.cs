using ConsoleTables;
using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.ProductServices
{
    public class ProductService
    {
        private static List<Product> Products = new List<Product>();

        public ProductService()
        {
            Products = new();
        }
        public static List<Product> ShowAllProducts()
        {
            return Products;
        }
        public static int AddProduct(string name, int quantity, string category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");

            if (quantity < 0)
                throw new FormatException("Quantity is invalid!");
            
            
            if (string.IsNullOrWhiteSpace(category))
                throw new FormatException("Category field is empty!");
            bool isSuccessful
                = Enum.TryParse<Category>(category, true, out Category parsedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!");
            }


            if (price < 0)
                throw new FormatException("Price is lower than 0!");

            var newProduct = new Product
            {
                Name = name,
                Quantity = quantity,
                Category = (Category)parsedCategory,
                Price = price
            };
            Products.Add(newProduct); 
            return newProduct.Id;
        }
        public static void RemoveProductById(int Id)
        {
            var existingProduct = Products.FirstOrDefault(x => x.Id == Id);
            if (existingProduct == null)
                throw new Exception($"{Id} not found!");
            Products = Products.Where(x => x.Id != Id).ToList();
        }
        public static void UpdateProductById(int Id, string newName, int newQuantity, Category newCategory, decimal newPrice)
        {
            var existingProduct = Products.FirstOrDefault(x => x.Id == Id);
            if (existingProduct == null)
                throw new Exception($"{Id} not found!");
            existingProduct.Name = newName;
            existingProduct.Quantity = newQuantity;
            existingProduct.Category = newCategory;
            existingProduct.Price = newPrice;
            
        }
        public static void ShowProductsByCategory(int categoryNumber)
        {
            if (!Enum.IsDefined(typeof(Category), categoryNumber))
            {
                Console.WriteLine("Invalid category number!");
                return;
            }

            Category selectedCategory = (Category)categoryNumber;
            var productsInCategory = Products.Where(x => x.Category == selectedCategory).ToList();

            Console.WriteLine($"Showing products in the {selectedCategory} category:");

            if (productsInCategory.Count == 0)
            {
                Console.WriteLine("No products found in this category.");
            }
            else
            {
                var table = new ConsoleTable("Id", "Name", "Category", "Price", "Quantity");
                foreach (var product in productsInCategory)
                {
                    table.AddRow(product.Id, product.Name, product.Category, product.Price, product.Quantity);
                }
                table.Write();
            }
        }
        public static List<Product> ShowProductsByPriceRange(decimal min, decimal max)
        {
            var productsinrange = Products.Where(x => x.Price >= min && x.Price <= max).ToList();
            return productsinrange;
            if (min > max)
                throw new Exception("Minimum price can not be greater than maximum price!");

        }
        public static List<Product> ShowProductByName(string name)
        {
            var existingproduct = Products.Find(x => x.Name == name);
            if (existingproduct == null)
                throw new Exception($"{name} not found!");
            var productbyname = Products.Where(x => x.Name == name).ToList();
            Products = productbyname;
            return productbyname;
        }
    }

}



