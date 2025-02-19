namespace INVMS.ProductManagement;
internal class ProductService(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;

    public void AddProduct()
    {
        while (true)
        {
            Console.WriteLine("************************");
            Console.WriteLine("* Add New Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter the product name");
            var name = Console.ReadLine();
            if (_productRepository.GetProduct(name) == null)
            {
                Console.Clear();
                double price = Utilities<double>.GetNumber("Enter the product price", double.TryParse);
                int quantity = Utilities<int>.GetNumber("Enter the product quantity", int.TryParse);
                if (_productRepository.AddProduct(name, price, quantity))
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

    public void RemoveProduct()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("* Deelte a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you wont to delete");
            var name = Console.ReadLine();
            if (_productRepository.RemoveProduct(name))
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

    public void EditProduct()
    {
        while (true)
        {
            Console.WriteLine("************************");
            Console.WriteLine("* Edit a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you wont to edit");
            var name = Console.ReadLine();
            var product = _productRepository.GetProduct(name);
            if (product == null)
            {
                Console.WriteLine($"!!! Product {name} not exist in the inventory !!!");
            }
            else
            {
                Console.Clear();
                if (_productRepository.EditProduct(product))
                {
                    Console.WriteLine($"Product {name} Edited Successfully");            
                }
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

    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public void FindProduct()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("* Search for a Product *");
            Console.WriteLine("************************");
            Console.WriteLine("Enter product name you want to search");
            var name = Console.ReadLine();
            var product = _productRepository.GetProduct(name);
            if (product != null)
            {
                Console.WriteLine(product);
            }
            else
            {
                Console.WriteLine("!!! This product not exist on the inventory !!!");
            }
            Console.WriteLine("************************");
            Console.WriteLine("************************");
            Console.WriteLine("To Search more Products Press 1");
            Console.WriteLine("Press any other key To Exit and Back to Main Menu ");
            var userOption = Console.ReadLine();
            if (userOption != "1")
            {
                break;
            }
        }
    }

    public Product? GetProduct(string name)
    {
        return _productRepository.GetProduct(name);
    }
    public void Init()
    {
        _productRepository.AddProduct("Watch", 50, 4);
        _productRepository.AddProduct("Carpet", 1500,2);
        _productRepository.AddProduct("TV", 2499.99, 7);
    }
}

