namespace INVMS.ProductManagement;
internal class ProductRepository : IProductRepository
{
    private List<Product> products;

    public ProductRepository() 
    { 
        products = new List<Product>();
    }

    public bool AddProduct(string name, double price, int quantity)
    {
        if (GetProduct(name) == null)
        {
            Product product = new Product(name, quantity, price);
            products.Add(product);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveProduct(string productName)
    {
        var product = GetProduct(productName);
        if (product != null)
        {
            products.Remove(product);
            return true;
        }
        else
        {
            return false;
        }    
    }

    public Product? GetProduct(string productName)
    {      
        var product = products.Find(product =>  product.Name == productName);
        return product;
    }

    public bool EditProduct(Product product)
    {
        Console.WriteLine("************************");
        Console.WriteLine("Select Field You Want to Edit");
        Console.WriteLine("1: Edit product name");
        Console.WriteLine("2: Edit product price");
        Console.WriteLine("3: Edit product quantity");
        Console.WriteLine("Press any other key To Exit");

        var userSelection = Console.ReadLine();
        switch (userSelection)
        {
            case "1":
                string newName = ReadProductName();
                product.Name = newName;
                break;
            case "2":
                product.Price = Utilities<double>.GetNumber("Enter the product price", double.TryParse);
                break;
            case "3":
                product.Quantity = Utilities<int>.GetNumber("Enter the product quantity", int.TryParse);
                break;
            default:
                return false;
        }
        return true;
    }
    
    public List<Product> GetAllProducts()
    {
        return products;
    }

    private string ReadProductName()
    {
        bool isValid = false;
        string? name;
        do
        {
            Console.WriteLine("Enter the product name");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || GetProduct(name) != null)
            {
                Console.WriteLine("!!! Product name is already exist in inventory !!!");
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        return name;
    }
}