namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts;
    using MyCoolWebServer.Database.Data;
    using MyCoolWebServer.Database.Models;

    public class OrderRepository : IOrderRepository
    {
        private CakeContext context;

        public OrderRepository(CakeContext context)
        {
            this.context = context;
        }

        public void Add(Order op)
        {
            this.context.Orders.Add(op);
        }

        public Order Find(int id)
        {
            Order order = this.context
                .Orders
                .Include(o => o.Products)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(o => o.Id == id);

            return order;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
