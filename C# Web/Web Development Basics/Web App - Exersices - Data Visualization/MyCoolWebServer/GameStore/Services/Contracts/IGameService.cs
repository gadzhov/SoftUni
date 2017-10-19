namespace MyCoolWebServer.GameStore.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public interface IGameService
    {
        IEnumerable<GameViewModel> GetAll();

        void Create(string title, string description, double size, decimal price, string imgUrl, string videoUrl, DateTime release);

        GameViewModel Get(int id);

        bool Edit(int id, string title, string description, string imgUrl, string priceString,
            string sizeString,
            string videoUrl, string releaseAsString);

        bool Delete(int id);
    }
}
