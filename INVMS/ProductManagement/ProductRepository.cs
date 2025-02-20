namespace INVMS.ProductManagement;
internal class ProductRepository : IProductRepository
{
    private List<Product> _products = new();

    public async Task<bool> AddProduct(string? name, double price, int quantity)
    {
        if (await GetProduct(name) != null) return false;
        return await Task.Run(() =>
        {
            var product = new Product(name, quantity, price);
            _products.Add(product);
            return true;
        });
    }
   
    public async Task<bool> RemoveProduct(string? productName)
    {
        var product = await GetProduct(productName);
        if (product == null) return false;
        await Task.Run(() => _products.Remove(product));
        return true;
    }
    
    public async Task<Product?> GetProduct(string? productName)
    {
        return await Task.Run(() => 
            _products.FirstOrDefault(p => p.Name == productName)
        );
    }
    
    public async Task<bool> EditProduct(Product product)
    {
        return await Task.Run(async () =>
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
                    var newName = await ReadProductName();
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
        });
    }
    
    public async Task<List<Product>> GetAllProducts()
    {
        return await Task.Run(() => _products); 
    }
    
    private async Task<string?> ReadProductName()
    {
        return await Task.Run(async () =>
        {
            var isValid = false;
            string? name;
            do
            {
                Console.WriteLine("Enter the product name");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || await GetProduct(name) != null)
                {
                    Console.WriteLine("!!! Product name is already exist in inventory !!!");
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);
            return name;
        });
    }
}