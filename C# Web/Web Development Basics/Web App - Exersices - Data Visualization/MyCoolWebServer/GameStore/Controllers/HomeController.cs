namespace MyCoolWebServer.GameStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using Security;
    using Server.Http;
    using Services;
    using Services.Contracts;
    using ViewModels;
    using Server.Http.Contracts;

    public class HomeController : Controller
    {
        private IGameService gameService;

        public HomeController(IHttpRequest req)
            : base(req)
        {
            this.gameService = new GameService();
        }

        public IHttpResponse Index()
        {
            string cardGroup = string.Empty;

            if (this.Request.UrlParameters.ContainsKey("filter"))
            {
                if (this.Request.UrlParameters["filter"] == "All")
                {
                    cardGroup = this.AllGames();
                }
                else if (this.Request.UrlParameters["filter"] == "Owned")
                {
                    cardGroup = this.OwnedGames();
                }
            }
            else
            {
                cardGroup = this.AllGames();
            }


            this.ViewData["card-group"] = cardGroup;

            return this.FileViewResponse(@"home\index");
        }

        private string OwnedGames()
        {
            string cardGroup = string.Empty;
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);

            if (auth != null)
            {
                List<int> gamesId = auth.OwnedGamesId;
                List<GameViewModel> games = new List<GameViewModel>();

                foreach (int id in gamesId)
                {
                    games.Add(this.gameService.Get(id));
                }

                if (games.Any())
                {
                    int counter = 0;
                    foreach (GameViewModel game in games)
                    {
                        // 4 game-card per row
                        if (counter == 0 || counter % 4 == 0)
                        {
                            cardGroup += @"<div class=""card-group"">";
                        }
                        cardGroup += $@"<div class=""card col-3""><img class=""card-img-top img-thumbnail"" src=""{
                                game.ImageUrl
                            }"" onerror=""this.onerror=null;this.src='http://picolas.de/wp-content/uploads/2015/12/picolas-picture-not-available.jpg';"" alt=""Card image cap"">
                        <div class=""card-block"">
                            <h4 class=""card-title"">
                                {game.Title}
                            </h4>
                            <p><strong>Price</strong> - {game.Price}&euro;</p>
                            <p><strong>Size</strong> - {game.Size}GB</p>
                            <p class=""card-text"">{game.Description}</p>
                        <div class=""card-footer"">
                            ";
                        if (auth != null && auth.IsAdmin)
                        {
                            cardGroup +=
                                $@"<a href = ""\admin\games\edit\{
                                        game.Id
                                    }"" class=""card-button btn btn-warning btn-sm"">Edit</a>
                            <a href = ""\admin\games\delete\{
                                        game.Id
                                    }"" class=""card-button btn btn-danger btn-sm"">Delete</a>";
                        }
                        cardGroup +=
                            $@"<a href = ""\games\info\{
                                    game.Id
                                }"" class=""card-button btn btn-outline-info btn-sm"">Info</a>";
                        if (auth == null || !auth.OwnedGamesId.Contains(game.Id))
                        {
                            cardGroup +=
                                $@"<a href = ""\games\info\{
                                        game.Id
                                    }\add-to-shopping-card"" class=""card-button btn btn-info btn-sm"" >Buy</a>";
                        }
                        cardGroup += @"</div>
                        </div>
                        </div>";
                        // 4 game-card per row
                        if (counter + 1 % 4 == 0)
                        {
                            cardGroup += @"</div>";
                        }
                        counter++;
                    }
                }
            }

            return cardGroup;
            }

            private string AllGames()
            {
                string cardGroup = string.Empty;

                List<GameViewModel> games = this.gameService
                    .GetAll()
                    .ToList();

                Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);

                if (games.Any())
                {
                    int counter = 0;
                    foreach (GameViewModel game in games)
                    {
                        // 4 game-card per row
                        if (counter == 0 || counter % 4 == 0)
                        {
                            cardGroup += @"<div class=""card-group"">";
                        }
                        cardGroup += $@"<div class=""card col-3""><img class=""card-img-top img-thumbnail"" src=""{game.ImageUrl}"" onerror=""this.onerror=null;this.src='http://picolas.de/wp-content/uploads/2015/12/picolas-picture-not-available.jpg';"" alt=""Card image cap"">
                        <div class=""card-block"">
                            <h4 class=""card-title"">
                                {game.Title}
                            </h4>
                            <p><strong>Price</strong> - {game.Price}&euro;</p>
                            <p><strong>Size</strong> - {game.Size}GB</p>
                            <p class=""card-text"">{game.Description}</p>
                        <div class=""card-footer"">
                            ";
                        if (auth != null && auth.IsAdmin)
                        {
                            cardGroup +=
                                $@"<a href = ""\admin\games\edit\{game.Id}"" class=""card-button btn btn-warning btn-sm"">Edit</a>
                            <a href = ""\admin\games\delete\{game.Id}"" class=""card-button btn btn-danger btn-sm"">Delete</a>";
                        }
                        cardGroup += $@"<a href = ""\games\info\{game.Id}"" class=""card-button btn btn-outline-info btn-sm"">Info</a>";
                        if (auth == null || !auth.OwnedGamesId.Contains(game.Id))
                        {
                            cardGroup +=
                                $@"<a href = ""\games\info\{game.Id}\add-to-shopping-card"" class=""card-button btn btn-info btn-sm"" >Buy</a>";
                        }
                        cardGroup += @"</div>
                        </div>
                        </div>";
                        // 4 game-card per row
                        if (counter + 1 % 4 == 0)
                        {
                            cardGroup += @"</div>";
                        }
                        counter++;
                    }
                }

                return cardGroup;
            }

            public IHttpResponse Info()
            {
                int id = int.Parse(this.Request.UrlParameters["id"]);
                GameViewModel game = this.gameService.Get(id);
                Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);

                this.ViewData["buy-button"] = "inline";
                if (auth == null || auth.OwnedGamesId.Contains(id))
                {
                    this.ViewData["buy-button"] = "none";
                }


                this.ViewData["bought-info"] = "none";
                if (this.Request.UrlParameters.ContainsKey("bought") && this.Request.UrlParameters["bought"] == "success")
                {
                    this.ViewData["bought-info"] = "block";
                }

                this.ViewData["game-title"] = game.Title;
                this.ViewData["game-videoUrl"] = game.YouTubeUrl;
                this.ViewData["game-description"] = game.Description;
                this.ViewData["game-price"] = game.Price;
                this.ViewData["game-size"] = game.Size;
                this.ViewData["game-release"] = game.Release;
                this.ViewData["game-id"] = game.Id.ToString();

                if (this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization) != null && this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization).IsAdmin)
                {
                    this.ViewData["admin-set"] = "inline";
                }
                else
                {
                    this.ViewData["admin-set"] = "none";
                }

                return this.FileViewResponse("Home/info");
            }
        }
    }
