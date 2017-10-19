namespace MyCoolWebServer.GameStore.Services
{
    using System;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Database.Data;
    using Database.Models;
    using ViewModels;

    public class GameService : IGameService
    {
        public IEnumerable<GameViewModel> GetAll()
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                return context
                    .Games
                    .Select(g => new GameViewModel
                    {
                        Id = g.Id,
                        Title = g.Title,
                        Price = g.Price.ToString(),
                        Size = g.Size.ToString(),
                        ImageUrl = g.ImageThumbnail,
                        Description = g.Description
                    })
                    .ToList();
            }
        }

        public void Create(string title, string description, double size, decimal price, string imgUrl, string videoUrl,
            DateTime release)
        {
            using (GameStoreContext context = new GameStoreContext())       
            {
                Game game = new Game
                {
                    Title = title,
                    Description = description,
                    Size = size,
                    Price = price,
                    ImageThumbnail = imgUrl,
                    Trailer = videoUrl,
                    ReleaseDate = release
                };

                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public GameViewModel Get(int id)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                if (context.Games.Any(g => g.Id == id))
                {
                    return context
                        .Games
                        .Select(g => new GameViewModel
                        {
                            Id = g.Id,
                            Price = g.Price.ToString(),
                            Size = g.Size.ToString(),
                            Title = g.Title,
                            Description = g.Description,
                            ImageUrl = g.ImageThumbnail,
                            YouTubeUrl = g.Trailer,
                            Release = g.ReleaseDate.ToShortDateString()
                        })
                        .FirstOrDefault(g => g.Id == id);
                }

                return null;
            }
        }

        public bool Edit(int id, string title, string description, string imgUrl, string priceString,
            string sizeString,
            string videoUrl, string releaseAsString)
        {
            using (GameStoreContext context = new GameStoreContext())   
            {
                if (context.Games.Any(g => g.Id == id))
                {
                    Game game = context.Games.FirstOrDefault(g => g.Id == id);
                    game.Description = description;
                    game.ImageThumbnail = imgUrl;
                    game.Price = decimal.Parse(priceString);
                    game.ReleaseDate = DateTime.Parse(releaseAsString);
                    game.Size = double.Parse(sizeString);
                    game.Title = title;
                    game.Trailer = videoUrl;

                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool Delete(int id)
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                Game game = context.Games.FirstOrDefault(g => g.Id == id);
                if (game != null)
                {
                    context.Games.Remove(game);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
