namespace MyCoolWebServer.GameStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using MyCoolWebServer.GameStore.Security;
    using MyCoolWebServer.GameStore.ViewModels;
    using Server.Http;
    using Services;
    using Services.Contracts;
    using Server.Http.Response;
    using Server.Http.Contracts;

    public class AccountController : Controller
    {
        private IUserService userService;
        private IGameService gameService;

        public AccountController(IHttpRequest req)
            : base(req)
        {
            this.userService = new UserService();
            this.gameService = new GameService();
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            if (req.Session.Contains(SessionStore.CurrentUserAuthorization))
            {
                return new RedirectResponse("/");
            }

            this.ViewData["alert-display"] = "none";
            if (this.ViewData.ContainsKey("alert-message"))
            {
                this.ViewData["alert-display"] = "block";
            }

            return this.FileViewResponse(@"Account/register");
        }

        public IHttpResponse Register(string email, string fullName, string password, string confirmPassword)
        {
            const string alertMsgInvalidEmail = "Invalid Email! It should contain @ sign and should be unique.";
            const string alertMsgInvalidPassword =
                "Invalid Password! It should be at least 6 symbols and should contain at least 1 uppercase, 1 lowercase letter and 1 digit.";
            const string alertMsgPasswordsNotMuch = "Confirm Password should match the provided password.";

            if (string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(fullName)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(confirmPassword))
            {
                return new BadRequestResponse();
            }
            // Email – must contain @ sign and a period. It must be unique.
            if (!email.Contains("@") || this.userService.Exist(email))
            {
                this.ViewData["alert-display"] = "block";
                this.ViewData["alert-message"] = alertMsgInvalidEmail;
                return this.FileViewResponse(@"Account/register");
            }

            // Password – length must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit
            if (password.Length < 6
                || !password.Any(char.IsUpper)
                || !password.Any(char.IsLower)
                || !password.Any(char.IsDigit))
            {
                this.ViewData["alert-display"] = "block";
                this.ViewData["alert-message"] = alertMsgInvalidPassword;

                return this.FileViewResponse(@"Account/register");
            }

            // Confirm Password – must match the provided password

            if (password != confirmPassword)
            {
                this.ViewData["alert-display"] = "block";
                this.ViewData["alert-message"] = alertMsgPasswordsNotMuch;

                return this.FileViewResponse(@"Account/register");
            }

            this.userService.Add(email, password, fullName);

            return new RedirectResponse("/login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            if (req.Session.Contains(SessionStore.CurrentUserAuthorization))
            {
                return new RedirectResponse("/");
            }

            this.ViewData["alert-display"] = "none";
            if (this.ViewData.ContainsKey("alert-message"))
            {
                this.ViewData["alert-display"] = "block";
            }
            return this.FileViewResponse(@"Account\login");
        }

        public IHttpResponse Login(string email, string password, IHttpRequest req)
        {
            const string invalidEmailOrPassword = "Email or Password is invalid!";
            const string allFieldsAreRequired = "AllFields are required!";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                this.ViewData["alert-message"] = allFieldsAreRequired;

                return this.FileViewResponse("Account/login");
            }

            if (!this.userService.TryLogin(email, password))
            {
                this.ViewData["alert-message"] = invalidEmailOrPassword;

                return this.FileViewResponse("Account/login");
            }

            Authorization auth = this.userService.Get(email);
            req.Session.Add(SessionStore.CurrentUserAuthorization, auth);

            return new RedirectResponse("/");
        }

        public IHttpResponse ShopingCard()
        {
            string result = String.Empty;
            if (this.Request.Session.Contains(SessionStore.TempGames))
            {
                List<GameViewModel> tempGames = this.Request.Session.Get<List<GameViewModel>>(SessionStore.TempGames);
                decimal totalSum = 0;
                foreach (GameViewModel game in tempGames)
                {
                    result += $@"<div class=""list-group"">
                    <div class=""list-group-item"" >
                        <div class=""media"" >
                            <a class=""btn btn-outline-danger btn-lg align-self-center mr-3"" href=""/shopping-card/remove/{game.Id}"" >X</a>
                            <img class=""d-flex mr-4 align-self-center img-thumbnail"" height=""127"" src=""{game.ImageUrl}""
                                 width=""227"" alt=""Generic placeholder image"">
                            <div class=""media-body align-self-center"">
                                <a href=""#"">
                                    <h4 class=""mb-1 list-group-item-heading""> {game.Title} </h4>
                                </a>
                                <p>
                                    {game.Description}
                                </p>
                            </div>
                            <div class=""col-md-2 text-center align-self-center mr-auto"">
                                <h2> {game.Price}&euro; </h2>
                            </div>
                        </div>
                    </div
                </div>";
                    totalSum += decimal.Parse(game.Price);
                }
                result += $@"<br />
                <div class=""col-8 ml-auto mr-auto mt-5 text-center"">
                    <h1><strong>Total Price - </strong> {totalSum} &euro;";

                if (totalSum != 0)
                {
                    result +=
                        "<div class=\"col-8  ml-auto mr-auto my-3\">\r\n                    <form method=\"post\">\r\n\r\n                        <input type=\"submit\" class=\"btn btn-success btn-lg btn-block\" value=\"Order\" />\r\n                    </form>\r\n                </div>";
                }
            }

            this.ViewData["list-group"] = result;

            return this.FileViewResponse("Account/shopping-card");
        }

        public IHttpResponse AddToShopingCard()
        {
            int id = int.Parse(this.Request.UrlParameters["id"]);
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);

            if (auth != null && auth.OwnedGamesId.Contains(id))
            {
                return new BadRequestResponse();
            }

            GameViewModel game = this.gameService.Get(id);

            if (!this.Request.Session.Contains(SessionStore.TempGames))
            {
                this.Request.Session.Add(SessionStore.TempGames, new List<GameViewModel> { game });
            }
            else
            {
                List<GameViewModel> tempGames = this.Request.Session.Get<List<GameViewModel>>(SessionStore.TempGames);
                tempGames.Add(game);
                this.Request.Session.Add(SessionStore.TempGames, tempGames);
                auth?.OwnedGamesId.AddRange(tempGames.Select(g => g.Id));
            }


            return new RedirectResponse($@"\games\info\{id}?bought=success");
        }

        public IHttpResponse RemoveFromShopingCard()
        {
            int id = int.Parse(this.Request.UrlParameters["id"]);
            GameViewModel game = this.gameService.Get(id);

            if (this.Request.Session.Contains(SessionStore.TempGames))
            {
                List<GameViewModel> tempGames = this.Request.Session.Get<List<GameViewModel>>(SessionStore.TempGames);
                List<GameViewModel> result = tempGames.Where(g => g.Id != id).ToList();
                this.Request.Session.Add(SessionStore.TempGames, result);
            }

            return new RedirectResponse(@"\shopping-card");
        }

        public IHttpResponse Proceed()
        {
            if (!this.Request.Session.Contains(SessionStore.CurrentUserAuthorization))
            {
                return new RedirectResponse(@"\login");
            }
            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);
            List<GameViewModel> games = this.Request.Session.Get<List<GameViewModel>>(SessionStore.TempGames);
            this.userService.AddGames(auth, games);
            auth.OwnedGamesId.AddRange(games.Select(g => g.Id));
            // Delete temp games;
            this.Request.Session.Add(SessionStore.TempGames, new List<GameViewModel>());

            return new RedirectResponse(@"\?filter=Owned");
        }

        public IHttpResponse Logout()
        {
            this.Request.Session.Clear();

            return new RedirectResponse(@"\");
        }
    }
}
