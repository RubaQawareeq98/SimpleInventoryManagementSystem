using INVMS.InventoryManagement;
using INVMS.ProductManagement;

namespace INVMS
{
    internal class Program
    {
        private static Inventory inventory = new Inventory(new ProductController());

        static void Main(string[] args)
        {
            Init();
            ShowMenu();

        }

        public static void Init()
        {
            inventory.AddProduct("Watch", 4, 50);
            inventory.AddProduct("Carpet", 2, 1500);
            inventory.AddProduct("TV", 7, 2499.99);
        }

        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Welcome To Inventory Management System");
                Console.WriteLine("********************");
                Console.WriteLine("* Select an action you want to do with Products *");
                Console.WriteLine("********************");

                Console.WriteLine("1: Add new product");
                Console.WriteLine("2: View all exist products");
                Console.WriteLine("3: Edit product details");
                Console.WriteLine("4: Delete a product");
                Console.WriteLine("5: Search for a product");
                Console.WriteLine("6: Close application");
                Console.WriteLine("********************");

                string? userSelection = Console.ReadLine();
                if (userSelection == "6")
                {
                    Console.WriteLine("*** Good Bye ***");
                    break;
                }

                HandleUserSelection(userSelection);
            }
        }

        public static void HandleUserSelection(string? userSelection)
        {
            switch (userSelection)
            {
                case "1":
                    HandleAddProduct();
                    break;
                case "2":
                    HandleViewProducts();
                    break;
                case "3":
                    HandleEditProduct();
                    break;
                case "4":
                    HandleRemoveProduct();
                    break;
                case "5":
                    HandleSearchProduct();
                    break;


                default:
                    Console.WriteLine("!!! Enter a Valid Input !!!");

                    break;

            }

        }
        public static void ShowAllProducts(IEnumerable<Product> products)
        {
            if (products.Count() == 0)
            {
                Console.WriteLine("************************");
                Console.WriteLine("!!! There is no product in the inventory !!!");
                Console.WriteLine("************************");

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{"".PadLeft(46, '=')}");
                Console.WriteLine($"| {"Name".PadRight(20)} | {"Price".PadRight(8)} | {"Quantity".PadRight(8)} |");
                Console.WriteLine($"{"".PadLeft(46, '=')}");
                Console.ResetColor();

                foreach (var product in products)
                {
                    Console.WriteLine(product);

                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{"".PadLeft(46, '=')}");
                Console.ResetColor();
            }

        }

        public static void HandleAddProduct()
        {
            Console.ResetColor();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Add Product *");
                Console.WriteLine("************************");

                Console.WriteLine("Enter the product name");
                string? name = Console.ReadLine();
                double price = Utilities<double>.GetNumber("Enter the product price", double.TryParse);
                int quantity = Utilities<int>.GetNumber("Enter the product quantity", int.TryParse);

                inventory.AddProduct(name, quantity, price);

                Console.WriteLine("************************");
                Console.WriteLine("1: Add more product");
                Console.WriteLine("2: Back to main menu");

                string? userSelection = Console.ReadLine();

                if (userSelection == "2")
                    break;
                else if (userSelection != "1")
                    Console.WriteLine("!!! Enter a Valid Input !!!");
            }
        }


        public static void HandleViewProducts()
        {
            while (true)
            {
                Console.Clear();
                var products = inventory.GetProducts();
                ShowAllProducts(products);
                Console.WriteLine("************************");
                Console.WriteLine("1: Back to main menu");
                string? userSelection = Console.ReadLine();
                if (userSelection == "1")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!! Enter a Valid Input !!!");

                }
            }


        }

        public static void HandleSearchProduct()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Search for a Product *");
                Console.WriteLine("************************");
                Console.WriteLine("Enter product name you wont to search");

                string? name = Console.ReadLine();
                var product = inventory.GetProduct(name);
                if (product != null)
                {
                    Console.WriteLine(product);
                }
                else
                {
                    Console.WriteLine("!!! This product not exist on the inventory !!!");

                }
                Console.WriteLine("************************");
                Console.WriteLine("1: Search for product");
                Console.WriteLine("2: Back to main menu");
                string? userSelection = Console.ReadLine();
                if (userSelection == "2")
                {
                    break;

                }
                else if (userSelection != "1")
                    Console.WriteLine("!!! Enter a Valid Input !!!");
            }
        }

        public static void HandleEditProduct()
        {
            while (true)
            {
                Console.WriteLine("************************");
                Console.WriteLine("* Edit a Product *");
                Console.WriteLine("************************");
                Console.WriteLine("Enter product name you wont to edit");
                string? name = Console.ReadLine();
                var product = inventory.GetProduct(name);
                if (product == null)
                {
                    Console.WriteLine($"!!! Product {name} not exist in the inventory !!!");


                }
                else
                {
                    Console.Clear();
                    inventory.EditProduct(product);
                }
                Console.WriteLine("************************");
                Console.WriteLine("1: Edit more products");
                Console.WriteLine("2: Back to main menu");
                string? userSelection = Console.ReadLine();
                if (userSelection == "2")
                {
                    break;

                }
                else if (userSelection != "1")
                    Console.WriteLine("!!! Enter a Valid Input !!!");

            }

        }

        public static void HandleRemoveProduct()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Deelte a Product *");
                Console.WriteLine("************************");
                Console.WriteLine("Enter product name you wont to delete");
                string? name = Console.ReadLine();
                inventory.RemoveProduct(name);

                Console.WriteLine("************************");
                Console.WriteLine("1: Delete more products");
                Console.WriteLine("2: Back to main menu");
                string? userSelection = Console.ReadLine();
                if (userSelection == "2")
                {
                    break;

                }
                else if (userSelection != "1")
                    Console.WriteLine("!!! Enter a Valid Input !!!");
            }
        }



    }
}

