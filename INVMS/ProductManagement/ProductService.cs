namespace INVMS.ProductManagement;
internal class ProductService(IProductRepository productRepository)
{
    public async Task AddProduct()
    {
        while (true)
        {
            Console.WriteLine("************************");
            Console.WriteLine("* Add New Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter the product name");
            var name = Console.ReadLine();
            if (await productRepository.GetProduct(name) == null)
            {
                Console.Clear();
                var price = Utilities<double>.GetNumber("Enter the product price", double.TryParse);
                var quantity = Utilities<int>.GetNumber("Enter the product quantity", int.TryParse);
                if (await productRepository.AddProduct(name, price, quantity))
                {
                    Console.WriteLine($"*** Product {name} Added Successfully ***"); 
                }
            }
            else
            {
                Console.WriteLine($"Product {name} already exist on the inventory");
            }
            Console.WriteLine("To Add new Product Press 1");
            Console.WriteLine("Press any other key To Exit and Back to Main Menu ");
            var userOption = Console.ReadLine();
            if (userOption != "1")
            {
                break;
            }
        }
    }
    
    public async Task FindProduct()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("* Search for a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you want to search:");

            var name = Console.ReadLine();
            try
            {
                var product = await GetProduct(name);
                Console.WriteLine(product);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("************************");
            Console.WriteLine("To search for more products, press 1");
            Console.WriteLine("Press any other key to exit and return to the main menu:");
            var userOption = Console.ReadLine();
            if (userOption != "1")
            {
                break;
            }
        }
    }
    
    public async Task RemoveProduct()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("* Delete a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you wont to delete");
            var name = Console.ReadLine();
            if (await productRepository.RemoveProduct(name))
            {
                Console.WriteLine($"Product {name} Deleted Successfully");
            }
            else
            {
                Console.WriteLine($"Delete failed; product {name} not exist");
            }
            Console.WriteLine("************************");
            Console.WriteLine("To Delete more Products Press 1");
            Console.WriteLine("Press any other key To Exit and Back to Main Menu ");
            var userOption = Console.ReadLine();
            if (userOption != "1")
            {
                break;
            }
        }
    }
    
    private async Task<Product?> GetProduct(string? name)
    {
        var product = await productRepository.GetProduct(name);
        if (product == null)
        {
            throw new KeyNotFoundException($"!!! The product {name} does not exist in the inventory !!!");
        }
        return product;
    }
    
    public async Task EditProduct()
    {
        while (true)
        {
            Console.WriteLine("************************");
            Console.WriteLine("* Edit a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you wont to edit");
            var name = Console.ReadLine();
            try
            {
                var product = await GetProduct(name);
                Console.Clear();
                if (await productRepository.EditProduct(product))
                {
                    Console.WriteLine($"Product {name} Edited Successfully");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("************************");
            Console.WriteLine("To Edit more Products Press 1");
            Console.WriteLine("Press any other key To Exit and Back to Main Menu ");
            var userOption = Console.ReadLine();
            if (userOption != "1")
            {
                break;
            }
        }
    }
    
    public async Task<List<Product>> GetProducts()
    {
        return await productRepository.GetAllProducts();
    }

    public void Init()
    {
        productRepository.AddProduct("Watch", 50, 4);
        productRepository.AddProduct("Carpet", 1500, 2);
        productRepository.AddProduct("TV", 2499.99, 7);
    }
}