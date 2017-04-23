namespace Local_Store
{
using System.Collections.Generic;
using System.Data.Entity;
using Local_Store.Models;
    public class InitializerSeed : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var products = new List<Product>()
            {
                new Product() { Name = "Banica", Description = "Mazna Banica", DistributorName = "Bai Ivan", Price = 1.2m },
                new Product() { Name = "Boza", Description = "Bozata na Bai Ivan", DistributorName = "Bai Ivan", Price = 0.80m },
                new Product() { Name = "Vodka", Description = "Alkohol", DistributorName = "Bai Ivan", Price = 12.50m }
            };
            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            base.Seed(context);
        }
    }
}
