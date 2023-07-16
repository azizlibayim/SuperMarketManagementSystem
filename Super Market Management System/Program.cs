using Super_Market_Management_System.Services.MenuServices;
using Super_Market_Management_System.Services.MenuServices;

namespace Super_Market_Management_System
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("1. For managing Products");
                Console.WriteLine("2. For managing Sales");
                Console.WriteLine("0. Exit");
                Console.WriteLine("-----------");
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
                        SubMenu.ProductSubMenu();
                        break;
                    case 2:
                        SubMenu.SalesSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the system...");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}
