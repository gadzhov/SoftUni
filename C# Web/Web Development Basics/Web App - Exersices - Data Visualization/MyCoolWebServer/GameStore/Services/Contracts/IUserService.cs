namespace MyCoolWebServer.GameStore.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels;
    using Security;

    public interface IUserService
    {
        bool Exist(string email);

        void Add(string email, string password, string fullName);

        bool TryLogin(string email, string password);

        Authorization Get(string email);

        void AddGames(Authorization auth, List<GameViewModel> games);
    }
}
