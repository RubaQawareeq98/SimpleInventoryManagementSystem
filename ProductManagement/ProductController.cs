using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace INVMS.ProductManagement
{
    internal class ProductController : IProductFunctionality
    {
        private List<Product> products;

        public ProductController() 
        { 
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"*** Product {product.Name} Added Successfully ***");

       
        public Product? GetProduct(string productName)
        {
            foreach (var product in products)
            {
                if (product.Name == productName) return product;
            }

            return null;
        }
      

    }
}
