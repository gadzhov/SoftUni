namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts
{
    using MyCoolWebServer.Database.Models;

    public interface IUserRepository
    {
        void Add(User user);

        void Save();

        User Get(string userName);
    }
}
