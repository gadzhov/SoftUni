namespace MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts
{
    using System.Collections.Generic;
    using MyCoolWebServer.Database.Models;

    public interface ICakeRepository
    {
        void Add(string name, decimal price, string pictureUrl);

        IEnumerable<Product> Search(string searchTerm);

        Product Find(int id);

        void Save();
    }
}
