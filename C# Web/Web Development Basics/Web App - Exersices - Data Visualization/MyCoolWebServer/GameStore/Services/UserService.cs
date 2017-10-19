namespace MyCoolWebServer.GameStore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Data;
    using Database.Models;
    using MyCoolWebServer.GameStore.ViewModels;
    using Security;
    using Services.Contracts;

    public class UserService : IUserService
    {
        public bool Exist(string email)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                return context.Users.Any(u => u.Email == email);
            }
        }

        public void Add(string email, string password, string fullName)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                User user = new User
                {
                    Email = email,
                    Password = password,
                    FullName = fullName
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool TryLogin(string email, string password)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                return context.Users.Any(u => u.Email == email && u.Password == password);
            }
        }

        public Authorization Get(string email)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                return context
                    .Users
                    .Select(u => new Authorization
                    {
                        Id = u.Id,
                        Name = u.FullName,
                        IsAdmin = u.IsAdmin,
                        OwnedGamesId = u.Games.Select(g => g.GameId).ToList()
                    })
                    .FirstOrDefault();
            }
        }

        public void AddGames(Authorization auth, List<GameViewModel> games)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                User user = context
                    .Users
                    .Find(auth.Id);

                foreach (GameViewModel game in games)
                {
                    user
                    .Games
                    .Add(new GameOwner
                    {
                        GameId = game.Id
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
