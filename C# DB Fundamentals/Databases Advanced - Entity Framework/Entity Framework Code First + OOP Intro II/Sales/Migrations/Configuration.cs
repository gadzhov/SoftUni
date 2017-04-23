using System.Collections.Generic;
using Sales.Models;

namespace Sales.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sales.SaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Sales.SaleContext";
        }

        protected override void Seed(Sales.SaleContext context)
        {
            var customers = new List<Customer>()
            {
                new Customer() { FirstName = "Ivan", LastName = "Andonov", Email = "dwad@dw.bg", CreditCardNumber = 2831931 },
                new Customer() { FirstName = "Dimitar", LastName = "Petrov", Email = "dwdwaad@dw.bg", CreditCardNumber = 282331931 },
                new Customer() { FirstName = "Marina", LastName = "Popova", Email = "dw23ad@dw.bg", CreditCardNumber = 2831131 },
                new Customer() { FirstName = "Kalina", LastName = "Sarapova", Email = "dwawdd@dw.bg", CreditCardNumber = 2831931 }
            };
            foreach (var customer in customers)
            {
                context.Customers.AddOrUpdate(customer);
            }

            var products = new List<Product>()
            {
                new Product() { Name = "Huawei", Description = "Smartphone", Price = 900, Quantity = 1},
                new Product() { Name = "Samsun", Description = "TV", Price = 1300, Quantity = 12},
                new Product() { Name = "Mercedes", Description = "Car", Price = 122200, Quantity = 1},
                new Product() { Name = "Seat", Description = "Car", Price = 12000, Quantity = 5},
                new Product() { Name = "AMD", Description = "MicroChip", Price = 450, Quantity = 10},
            };
            foreach (var product in products)
            {
                context.Products.AddOrUpdate(product);
            }
            // Continue add Initialize data
            context.SaveChanges();
        }
    }
}
