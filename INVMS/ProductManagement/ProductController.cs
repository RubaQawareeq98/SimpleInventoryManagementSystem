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

        }
        public void RemoveProduct(string productName)
        {
            var product = GetProduct(productName);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Product {productName} Deleted Successfully");
            }
            else
            {
                Console.WriteLine($"Delete failed; product {productName} not exist");

            }
        }
        public Product? GetProduct(string productName)
        {
            foreach (var product in products)
            {
                if (product.Name == productName) return product;
            }

            return null;
        }
        public void EditProduct(Product product)
        {
            Console.WriteLine("************************");
            Console.WriteLine("1: Edit product name");
            Console.WriteLine("2: Edit product price");
            Console.WriteLine("3: Edit product quantity");
            Console.WriteLine("4: Back to main menu");

            string? userSelection = Console.ReadLine();
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
                case "4":
                    return;

                default:
                    Console.WriteLine("!!! Enter a Valid Input !!!");
                    break;
            }

        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        private string ReadProductName()
        {
            bool b = false;
            string? name;
            do
            {
                Console.WriteLine("Enter the product name");
                name = Console.ReadLine();
                if (GetProduct(name) != null)
                {
                    Console.WriteLine("!!! Product name is already exist in inventory !!!");
                }
                else
                    b = true;

            } while (!b);
            return name;

        }


    }
}
