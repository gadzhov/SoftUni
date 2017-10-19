namespace MyCoolWebServer.GameStore
{
    using Controllers;
    using MyCoolWebServer.GameStore.ViewModels;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class GameStoreApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new HomeController(req).Index());
            appRouteConfig
                .Get("/register", req => new AccountController(req).Register(req));
            appRouteConfig
                .Post("/register", req => new AccountController(req).Register(
                    req.FormData["email"],
                    req.FormData["fullName"],
                    req.FormData["password"],
                    req.FormData["confirmPassword"]));
            appRouteConfig
                .Get("/login", req => new AccountController(req).Login(req));
            appRouteConfig
                .Post("/login", req => new AccountController(req).Login(
                    req.FormData["email"],
                    req.FormData["password"],
                    req));
            appRouteConfig
                .Get("/admin/games", req => new AdminController(req).Index(req));
            appRouteConfig
                .Get("/admin/games/add-game", req => new AdminController(req).AddGame());
            appRouteConfig
                .Post("/admin/games/add-game", req => new AdminController(req).AddGame(
                    req.FormData["title"],
                    req.FormData["description"],
                    req.FormData["imgUrl"],
                    req.FormData["price"],
                    req.FormData["size"],
                    req.FormData["videoUrl"],
                    req.FormData["release"]));
            appRouteConfig
                .Get("/admin/games/edit/{(?<id>[0-9]+)}", req => new AdminController(req).Edit(int.Parse(req.UrlParameters["id"])));
            appRouteConfig
                .Post("/admin/games/edit/{(?<id>[0-9]+)}", req => new AdminController(req).Edit(
                    int.Parse(req.UrlParameters["id"]),
                    req.FormData["title"],
                    req.FormData["description"],
                    req.FormData["imgUrl"],
                    req.FormData["price"],
                    req.FormData["size"],
                    req.FormData["videoUrl"],
                    req.FormData["release"]));
            appRouteConfig
                .Get("/admin/games/delete/{(?<id>[0-9]+)}", req => new AdminController(req).DeleteGet(int.Parse(req.UrlParameters["id"])));
            appRouteConfig
                .Post("/admin/games/delete/{(?<id>[0-9]+)}", req => new AdminController(req).DeletePost(int.Parse(req.UrlParameters["id"])));
            appRouteConfig
                .Get("/games/info/{(?<id>[0-9]+)}", req => new HomeController(req).Info());
            appRouteConfig
                .Get("/shopping-card", req => new AccountController(req).ShopingCard());
            appRouteConfig
                .Post("shopping-card", req => new AccountController(req).Proceed());
            appRouteConfig
                .Get("games/info/{(?<id>[0-9]+)}/add-to-shopping-card", req => new AccountController(req).AddToShopingCard());
            appRouteConfig
                .Get("/shopping-card/remove/{(?<id>[0-9]+)}", req => new AccountController(req).RemoveFromShopingCard());
            appRouteConfig
                .Get("/logout", req => new AccountController(req).Logout());
        }
    }
}
