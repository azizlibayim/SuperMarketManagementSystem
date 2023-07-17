using Super_Market_Management_System.Common.Enums;
using Super_Market_Management_System.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Services.MenuServices
{
    public static class SubMenu
    {
        public static void ProductSubMenu ()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1.Add new product.");
                Console.WriteLine("2.Update the product.");
                Console.WriteLine("3.Delete the product.");
                Console.WriteLine("4.Show all products.");
                Console.WriteLine("5.Show all products by category.");
                Console.WriteLine("6.Find products in a given price range.");
                Console.WriteLine("7.Find product by name.");
                Console.WriteLine("--------------------");
                Console.WriteLine("0.Back");
                Console.WriteLine("Enter option:");
            
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                    Console.WriteLine("Invalid number!");
                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter option:");
            }
                switch (option)
                {
                    case 1:
                        MenuService.MenuAddProduct();
                        Console.WriteLine("Product is added successfully!");
                        break;
                    case 2:
                        MenuService.MenuUpdateProductById();
                        Console.WriteLine("Product is updated successfully!");
                        break;
                    case 3:
                        MenuService.MenuRemoveProductById();
                        Console.WriteLine("Product is deleted successfully!");
                        break;
                        case 4:
                        MenuService.MenuShowAllProducts();
                        Console.WriteLine("Here are all the products!");
                        break;
                        case 5:
                        Console.WriteLine("Here are all products!");
                        MenuService.MenuShowProductsByCategory();
                        break;
                        case 6:
                        MenuService.MenuShowProductsByPriceRange();
                        Console.WriteLine("Here are the products!");
                        break;
                        case 7:
                        MenuService.MenuShowProductByName();
                        Console.WriteLine("Here is the product!");
                        break;
                        case 0:
                    default:
                        Console.WriteLine("There is no such an option!");
                        break;
                }

            } while (option != 0);
        }
        public static void SalesSubMenu()
        {
                Console.Clear();
                int option;
                do
                {
                    Console.WriteLine("1.Add new sale.");
                    Console.WriteLine("2.Update the sale.");
                    Console.WriteLine("3.Delete the sale.");
                    Console.WriteLine("4.Show all sales.");
                    Console.WriteLine("5.Show all sales by period of time.");
                    Console.WriteLine("6.Show sales in a given price range.");
                    Console.WriteLine("7. Show all sales on a given date.");
                    Console.WriteLine("8. Show a sale by its number.");
                Console.WriteLine("--------------------");
                    Console.WriteLine("Enter option:");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid number!");
                        Console.WriteLine("-----------");
                        Console.WriteLine("Enter option:");
                    }
                    switch (option)
                {
                        case 1:
                        MenuService.MenuAddSale();
                            Console.WriteLine("Sale is added successfully!");
                            break;
                        case 2:
                            Console.WriteLine("Sale is updated successfully!");
                            break;
                        case 3:
                        Console.WriteLine("Sale is deleted successfully!");
                        MenuService.MenuRemoveSaleById();
                            break;
                        case 4:
                        Console.WriteLine("Here are all the sales!");
                        MenuService.MenuShowAllSales();
                            break;
                        case 5:
                        Console.WriteLine("Here are the sales!");
                        MenuService.MenuShowSalesByPeriod();
                            break;
                        case 6:
                            Console.WriteLine("Here are the sales!");
                            break;
                        case 7:
                        Console.WriteLine("Here are the sales!");
                        MenuService.MenuShowSalesByDate();
                            break;
                    case 8:
                        Console.WriteLine("Here is the sale!");
                        break;
                        default:
                            Console.WriteLine("There is no such an option!");
                            break;
                    }

                } while (option != 0);
            }
    }
    }

