namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts
{
    using MyCoolWebServer.Database.Models;

    public interface IOrderRepository
    {
        void Add(Order op);

        Order Find(int id);

        void Save();
    }
}
