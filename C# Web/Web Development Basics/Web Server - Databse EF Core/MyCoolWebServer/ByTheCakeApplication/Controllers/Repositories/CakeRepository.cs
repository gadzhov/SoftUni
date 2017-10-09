namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts;
    using MyCoolWebServer.Database.Data;
    using MyCoolWebServer.Database.Models;

    public class CakeRepository : ICakeRepository
    {
        private CakeContext context;

        public CakeRepository(CakeContext context)
        {
            this.context = context;
        }

        public void Add(string name, decimal price, string pictureUrl)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                ImageUrl = pictureUrl
            };

            this.context.Products.Add(product);
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            IEnumerable<Product> products =
                this.context
                .Products
                .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));

            return products;
        }

        public Product Find(int id)
        {
            Product product = this.context
                .Products
                .Find(id);

            return product;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
