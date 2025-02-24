using INVMS.ProductManagement;
namespace INVMS;
internal class Program
{
    private static readonly ProductService productService = new ProductService(new ProductRepository());

    static async Task Main(string[] args) 
    {
        productService.Init();
        await ShowMenu();
    }

    private static async Task ShowMenu()
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
            await HandleUserSelection(userSelection);
        }
    }

    private static async Task HandleUserSelection(string? userSelection)
    {
        switch (userSelection)
        {
            case "1":
                await productService.AddProduct();
                break;
            case "2":
                await HandleViewProducts();
                break;
            case "3":
                await productService.EditProduct();
                break;
            case "4":
                await productService.RemoveProduct();
                break;
            case "5":
                await productService.FindProduct();
                break;
            default:
                Console.WriteLine("!!! Enter a Valid Option Number !!!");
                break;
        }
    }

    private static void ShowAllProducts(List<Product> products)
    {
        if (!products.Any())
        {
            Console.WriteLine("************************");
            Console.WriteLine("!!! There is no product in the inventory !!!");
            Console.WriteLine("************************");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"".PadLeft(46, '=')}");
            Console.WriteLine($"| {"Name",-20} | {"Price",-8} | {"Quantity",-8} |");
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

    private static async Task HandleViewProducts()
    {
        Console.Clear();
        var products = await productService.GetProducts();
        ShowAllProducts(products);
        Console.WriteLine("************************");
        Console.WriteLine("Press any key To Exit and Back to Main Menu ");
        var userSelection = Console.ReadLine();
        
    }

}