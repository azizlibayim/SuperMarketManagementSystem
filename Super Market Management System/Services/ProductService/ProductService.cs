using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.ProductService
{
    public class ProductService
    {
        public static List<Product> Products;

        public ProductService()
        {
            Products = new();
        }
        public List<Product> ShowAllProducts()
        {
            return Products;
        }

        public static int AddProduct(string name, int Id, int quantity,
               string category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");

            if (quantity < 0)
                throw new FormatException("Quantity is invalid!");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");

            if (string.IsNullOrWhiteSpace(category))
                throw new FormatException("Category field is empty!");


            bool isSuccessful
                = Enum.TryParse<Category>(category, true, out Category parsedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!");
            }

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
            var productsInCategory = Products.Where(x => x.Category == selectedCategory);
            Console.WriteLine($"Showing products in the {selectedCategory} category:");
        }

        public static void ShowProductsByPriceRange(decimal min, decimal max)
        {
            var pricerange = Products.Where(x => x.Price >= min && x.Price <= max).ToList();
            if (min > max)
                throw new Exception("Minimum price can not be greater than maximum price!");

        }
        public static void ShowProductByName(string name)
        {
            var product = Products.Find(x => x.Name == name);
            if (product == null)
                throw new Exception($"{name} not found!");
        }
    }

}



