﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Sales.Models;

namespace Sales
{
    public class InitializeSeed : DropCreateDatabaseAlways<SaleContext>
    {
        protected override void Seed(SaleContext context)
        {
            /*
            Random rnd = new Random();
            string[] name = { "Ivan", "Gosho", "Pesho", "Stamat", "Spas", "Spaska", "Naska", "Conka", "Dochka" };
            string[] emails = { "sada@dsa.bg", "kdsak24@ads.dsa", "dsad2@f.bg" };

            for (int i = 0; i < 5; i++)
            {
                context.Customers.AddOrUpdate(new Customer()
                {
                    Name = name[rnd.Next(name.Length)],
                    Email = emails[rnd.Next(emails.Length)]
                });
            }

            string[] productNames = { "Ketchup", "Mayo", "Samsung S6", "Kiselo mlqko", "DVD" };

            for (int i = 0; i < 5; i++)
            {
                context.Products.AddOrUpdate(new Product()
                {
                    Name = productNames[rnd.Next(productNames.Length)],
                    Price = (decimal)rnd.NextDouble() * 100m,
                    Quantity = rnd.Next(10)
                });
            }

            string[] locationNames = { "Sofia", "Varna", "Plovdiv", "Panagiurishte", "Kostenets" };
            for (int i = 0; i < 5; i++)
            {
                context.StoreLocations.AddOrUpdate(new StoreLocation()
                {
                    LocationName = locationNames[rnd.Next(locationNames.Length)]
                });
            }


            Product[] products = context.Products.Local.ToArray();
            StoreLocation[] locations = context.StoreLocations.Local.ToArray();
            Customer[] customers = context.Customers.Local.ToArray();

            for (int i = 0; i < 5; i++)
            {
                context.Sales.AddOrUpdate(new Sale()
                {
                    Product = products[rnd.Next(products.Length)],
                    Customer = customers[rnd.Next(customers.Length)],
                    StoreLocation = locations[rnd.Next(locations.Length)]
                });
            }
            base.Seed(context);
            */
        }
    }
}
