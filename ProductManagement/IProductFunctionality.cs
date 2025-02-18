using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVMS.ProductManagement
{
    internal interface IProductFunctionality
    {
        public void AddProduct(Product product);
        public void RemoveProduct(string productName);
        public Product? GetProduct(string productName);  
        public void EditProduct (Product product);
        public IEnumerable<Product> GetAllProducts();


    }
}
