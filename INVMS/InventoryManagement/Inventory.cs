using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVMS.ProductManagement;

namespace INVMS.InventoryManagement
{
    internal class Inventory
    {
        private IProductFunctionality? _productFunctionality;
        public Inventory(IProductFunctionality productFunctionality)
        {
            _productFunctionality = productFunctionality;

        }

        public void AddProduct(string name, int quantity, double price)
        {
            if (_productFunctionality.GetProduct(name) == null)
            {
                Product product = new(name, quantity, price);
                _productFunctionality.AddProduct(product);
            }
            else
            {
                Console.WriteLine($"Product {name} already exist on the inventory");
            }
        }
        public void RemoveProduct(string name)
        {
            _productFunctionality.RemoveProduct(name);
        }
        public void EditProduct(Product product)
        {
            _productFunctionality.EditProduct(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productFunctionality.GetAllProducts();
        }
        public Product? GetProduct(string name)
        {
           return _productFunctionality.GetProduct(name);
        }

    }
}
