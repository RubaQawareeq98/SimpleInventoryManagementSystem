namespace INVMS.ProductManagement;
internal interface IProductRepository
{
    public bool AddProduct(string name, double price, int quantity);
    public bool RemoveProduct(string productName);
    public Product? GetProduct(string productName);  
    public bool EditProduct (Product product);
    public List<Product> GetAllProducts();
}