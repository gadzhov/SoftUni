using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProductsShop.Data.ProductsShopContext";
        }

        protected override void Seed(ProductsShop.Data.ProductsShopContext context)
        {
            //UsersSeed(context);
            //ProductsSeed(context);
            //CategoriesSeed(context);
        }

        private void CategoriesSeed(ProductsShopContext context)
        {
            var json = File.ReadAllText("../../Import/categories.json");
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
            var rnd = new Random();
            var countOfProducts = context.Products.Count();
            foreach (var category in categories)
            {
                for (int i = 0; i < countOfProducts / 2; i++)
                {
                    var product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private void ProductsSeed(ProductsShopContext context)
        {
            var json = File.ReadAllText("../../Import/products.json");
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            var rnd = new Random();
            foreach (var product in products)
            {
                var shouldHaveBuyer = rnd.NextDouble();
                product.SellerId = rnd.Next(1, context.Users.Count() + 1);
                if (shouldHaveBuyer < 0.8)
                {
                    product.BuyerId = rnd.Next(1, context.Users.Count() + 1);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private void UsersSeed(ProductsShopContext context)
        {
            var json = File.ReadAllText("../../Import/users.json");
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

            // using AddRange instead AddOrUpdate bcs there are dublicates LastNames. And seed method will run once!
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
