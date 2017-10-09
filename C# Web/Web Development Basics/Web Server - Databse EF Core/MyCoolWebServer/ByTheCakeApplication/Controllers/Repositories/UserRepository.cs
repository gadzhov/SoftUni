namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories
{
    using System.Linq;
    using Repositories.Contracts;
    using Database.Models;
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.Database.Data;

    public class UserRepository : IUserRepository
    {
        private CakeContext context;

        public UserRepository(CakeContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            this.context.Users.Add(user);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public User Get(string userName)
        {
            var user = this.context
                .Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.Products)
                .ThenInclude(po => po.Product)
                .FirstOrDefault(u => u.Username == userName);

            return user;
        }
    }
}
