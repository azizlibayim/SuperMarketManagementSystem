using Super_Market_Management_System.Services.MenuService;

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
                        MenuService.MenuProducts();
                        break;
                    case 2:
                        MenuService.SaleSubMenu();
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
}