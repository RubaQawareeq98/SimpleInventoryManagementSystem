using INVMS.ProductManagement;
namespace INVMS;
internal class Program
{
    private static ProductService productService = new ProductService(new ProductRepository());

    static void Main(string[] args)
    {
        productService.Init();
        ShowMenu();
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
            var userSelection = Console.ReadLine();
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
                productService.AddProduct();
                break;
            case "2":
                HandleViewProducts();
                break;
            case "3":
                productService.EditProduct();
                break;
            case "4":
                productService.RemoveProduct();
                break;
            case "5":
                productService.FindProduct();
                break;
            default:
                Console.WriteLine("!!! Enter a Valid Option Number !!!");
                break;
        }
    }

    public static void ShowAllProducts(List<Product> products)
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

    public static void HandleViewProducts()
    {
        Console.Clear();
        var products = productService.GetProducts();
        ShowAllProducts(products);
        Console.WriteLine("************************");
        Console.WriteLine("Press any key To Exit and Back to Main Menu ");
        var userSelection = Console.ReadLine();
        if (userSelection != null)
        {
            return;
        }        
    }
}

