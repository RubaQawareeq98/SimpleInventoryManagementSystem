namespace INVMS.ProductManagement;
internal interface IProductRepository
{
    public Task<bool> AddProduct(string? name, double price, int quantity);
    public Task<bool> RemoveProduct(string? productName);
    public Task<Product?> GetProduct(string? productName);
    public Task<bool> EditProduct (Product? product);
    public Task<List<Product>> GetAllProducts();
}