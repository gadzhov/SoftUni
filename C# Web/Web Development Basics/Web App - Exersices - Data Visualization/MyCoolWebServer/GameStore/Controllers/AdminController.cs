namespace MyCoolWebServer.GameStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using GameStore.Security;
    using ViewModels;
    using Services;
    using Services.Contracts;
    using Server.Http.Response;
    using Server.Http;
    using Server.Http.Contracts;

    public class AdminController : Controller
    {
        private IGameService gameService;

        public AdminController(IHttpRequest req)
            : base(req)
        {
            this.gameService = new GameService();
        }

        public IHttpResponse Index(IHttpRequest req)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            List<GameViewModel> games = this.gameService.GetAll().ToList();

            string trData = string.Empty;
            int counter = 1;

            foreach (var game in games)
            {
                trData +=
                    $@"<tr>
                          <th scope=""row"">{counter}</th>
                          <td>{game.Title}</td>
                          <td>{game.Size}</td>
                          <td>{game.Price}</td>
                          <td>
                            <a href=""\admin\games\edit\{game.Id}"" class=""btn btn-warning"">Edit</a>
                            <a href=""\admin\games\delete\{game.Id}"" class=""btn btn-danger"">Delete</a>
                          </td>
                       </tr>";

                counter++;
            }

            this.ViewData["tr-data"] = trData;

            return this.FileViewResponse("Admin/index");
        }

        public IHttpResponse AddGame()
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            this.ViewData["alert-display"] = "none";
            if (this.ViewData.ContainsKey("alert-message"))
            {
                this.ViewData["alert-display"] = "block";
            }

            return this.FileViewResponse("Admin/add-game");
        }

        public IHttpResponse AddGame(string title, string description, string imgUrl, string priceString, string sizeString,
            string videoUrl, string releaseAsString)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            if (!this.ValidateAllFields(title, description, imgUrl, priceString, sizeString, videoUrl, releaseAsString))
            {
                return this.FileViewResponse("Admin/add-game");
            }

            decimal price = decimal.Parse(priceString);
            double size = double.Parse(sizeString);
            DateTime release = DateTime.Parse(releaseAsString);

            this.gameService.Create(title, description, size, price, imgUrl, videoUrl, release);

            return new RedirectResponse(@"\admin\games");
        }

        public IHttpResponse Edit(int id)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            GameViewModel game = this.gameService.Get(id);

            if (game == null)
            {
                return new RedirectResponse(@"\");
            }

            this.ViewData["alert-display"] = "none";
            if (this.ViewData.ContainsKey("alert-message"))
            {
                this.ViewData["alert-display"] = "block";
            }

            this.ViewData["game-title"] = game.Title;
            this.ViewData["game-description"] = game.Description;
            this.ViewData["game-imgUrl"] = game.ImageUrl;
            this.ViewData["game-price"] = game.Price;
            this.ViewData["game-release"] = game.Release;
            this.ViewData["game-size"] = game.Size;
            this.ViewData["game-videoUrl"] = game.YouTubeUrl;
            this.ViewData["game-id"] = game.Id.ToString();

            return this.FileViewResponse(@"Admin/edit-game");
        }

        public IHttpResponse Edit(int id, string title, string description, string imgUrl, string priceString,
            string sizeString,
            string videoUrl, string releaseAsString)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            if (!this.ValidateAllFields(title, description, imgUrl, priceString, sizeString, videoUrl, releaseAsString))
            {
                return this.Edit(id);
            }

            if (!this.gameService.Edit(id, title, description, imgUrl, priceString, sizeString, videoUrl, releaseAsString))
            {
                return new BadRequestResponse();
            }

            return new RedirectResponse(@"\admin\games");
        }

        public IHttpResponse DeleteGet(int id)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            GameViewModel game = this.gameService.Get(id);

            if (game == null)
            {
                return new RedirectResponse(@"\");
            }

            this.ViewData["game-title"] = game.Title;
            this.ViewData["game-description"] = game.Description;
            this.ViewData["game-imgUrl"] = game.ImageUrl;
            this.ViewData["game-price"] = game.Price;
            this.ViewData["game-release"] = game.Release;
            this.ViewData["game-size"] = game.Size;
            this.ViewData["game-videoUrl"] = game.YouTubeUrl;
            this.ViewData["game-id"] = game.Id.ToString();

            return this.FileViewResponse("Admin/delete-game");
        }

        public IHttpResponse DeletePost(int id)
        {
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            if (auth == null || !auth.IsAdmin)
            {
                return new RedirectResponse("/");
            }

            if (!this.gameService.Delete(id))
            {
                return new BadRequestResponse();
            }

            return new RedirectResponse(@"\admin\games");
        }

        private bool ValidateAllFields(string title, string description, string imgUrl, string priceString, string sizeString,
            string videoUrl, string releaseAsString)
        {
            const string allFieldsAreRequired = "All fileds are requied!";
            const string titleRequirements = "Title has to begin with uppercase letter and has length between 3 and 100 symbols (inclusive)";
            const string priceRequirements = "Price must be a positive number with precision up to 2 digits after floating point";
            const string sizeRequirements = "Size must be a positive number with precision up to 1 digit after floating point";
            const string videoUrlRequirements = "Only videos from YouTube are allowed";
            const string descriptionRequirements = "Description must be at least 20 symbols";

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(imgUrl) || string.IsNullOrEmpty(priceString) || string.IsNullOrEmpty(sizeString) || string.IsNullOrEmpty(videoUrl) || string.IsNullOrEmpty(releaseAsString))
            {
                this.ViewData["alert-message"] = allFieldsAreRequired;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            // Title – has to begin with uppercase letter and has length between 3 and 100 symbols (inclusive)
            if (!char.IsUpper(title.First()) || title.Length < 3 || title.Length > 100)
            {
                this.ViewData["alert-message"] = titleRequirements;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            // Price –  must be a positive number with precision up to 2 digits after floating point
            decimal price = decimal.Parse(priceString);
            if (price < 0)
            {
                this.ViewData["alert-message"] = priceRequirements;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            double size = double.Parse(sizeString);
            // Size – must be a positive number with precision up to 1 digit after floating point
            if (size < 0)
            {
                this.ViewData["alert-message"] = sizeRequirements;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            // Only videos from YouTube are allowed
            if (videoUrl.Length != 11)
            {
                this.ViewData["alert-message"] = videoUrlRequirements;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            // Description – must be at least 20 symbols
            if (description.Length < 20)
            {
                this.ViewData["alert-message"] = descriptionRequirements;
                this.ViewData["alert-display"] = "block";

                return false;
            }

            return true;
        }
    }
}
