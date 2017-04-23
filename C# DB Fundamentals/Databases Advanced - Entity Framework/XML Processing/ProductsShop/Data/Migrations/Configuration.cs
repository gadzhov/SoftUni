using System.Xml.Linq;
using Models;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ProductShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.ProductShopContext";
        }

        protected override void Seed(Data.ProductShopContext context)
        {
            //SeedUsers();
            //SeedProducts();
            //SeedCategories();
        }

        private void SeedCategories()
        {
            using (var context = new ProductShopContext())
            {
                XDocument xmlDoc = XDocument.Load("../../../Data/Import/categories.xml");
                var categories = xmlDoc.Root.Elements();
                var countOfProducts = context.Products.Count();
                var rnd = new Random();
                foreach (var category in categories)
                {
                    var name = category.Element("name").Value;

                    var newCategory = new Category()
                    {
                        Name = name
                    };

                    for (int i = 0; i < countOfProducts / 5 ; i++)
                    {
                        var product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                        newCategory.Products.Add(product);
                    }

                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }
            }
        }

        private void SeedProducts()
        {
            using (var context = new ProductShopContext())
            {
                XDocument xmlDoc = XDocument.Load("../../../Data/Import/products.xml");
                var products = xmlDoc.Root.Elements();
                var rnd = new Random();
                foreach (var product in products)
                {
                    var isHasBuyer = rnd.NextDouble();
                    int? buyerId = null;
                    var sellerId = rnd.Next(1, context.Users.Count() + 1);
                    // ~ 20% chance buyer to be null
                    if (isHasBuyer < 0.8)
                    {
                        buyerId = rnd.Next(1, context.Users.Count() + 1);
                    }

                    var name = product.Element("name").Value;
                    var price = decimal.Parse(product.Element("price").Value);

                    var newProduct = new Product()
                    {
                        Name = name,
                        Price = price,
                        BuyerId = buyerId,
                        SellerId = sellerId
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();

                }
            }
        }

        private void SeedUsers()
        {
            using (var context = new ProductShopContext())
            {
                XDocument xmlDoc = XDocument.Load("../../../Data/Import/users.xml");
                var users = xmlDoc.Root.Elements();
                foreach (var user in users)
                {
                    string firstName = null;
                    var lastName = user.Attribute("last-name").Value;
                    int? age = null;

                    if (user.Attribute("first-name") != null)
                    {
                        firstName = user.Attribute("first-name").Value;
                    }
                    if (user.Attribute("age") != null)
                    {
                        age = int.Parse(user.Attribute("age").Value);
                    }

                    context.Users.Add(new User() {FirstName = firstName, LastName = lastName, Age = age});
                    context.SaveChanges();
                }
            }
        }
    }
}
