using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;

namespace ProductsShop
{
    class Startup
    {
        static void Main()
        {
            var context = new ProductsShopContext();
            //context.Database.Initialize(true);
            //ProductsInRange(context);
            //SuccessfullySoldProducts(context);
            //CategoriesByProductsCount(context);
            UsersAndProducts(context);
        }

        private static void UsersAndProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 1)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count,
                        products = u.ProductsSold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                });
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CategoriesByProductsCount(ProductsShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void SuccessfullySoldProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(user => user.ProductsSold.Count(product => product.Buyer != null) != 0)
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    soldProducts = user.ProductsSold.Select(product => new
                    {
                        product.Name,
                        product.Price,
                        buyerFirstName = product.Buyer.FirstName,
                        buyerLastName = product.Buyer.LastName
                    })
                });
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        private static void ProductsInRange(ProductsShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName != null ? p.Seller.FirstName + " " + p.Seller.LastName : p.Seller.LastName
                });
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
