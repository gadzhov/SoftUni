namespace WebServer.Application
{
    using WebServer.Application.Controllers;
    using WebServer.Server.Contracts;
    using WebServer.Server.Handlers;
    using WebServer.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetRequestHandler(httpContext => new HomeController().Index()));
            appRouteConfig.AddRoute("/favicon.ico", new GetRequestHandler(httpContext => new HomeController().Index()));
            appRouteConfig.AddRoute("/register",
                new PostRequestHandler(htpContext => new UserController().RegisterPost(htpContext.FormData["name"])));
            appRouteConfig.AddRoute("/register", new GetRequestHandler(httpContext => new UserController().RegisterGet()));
            appRouteConfig.AddRoute("/user/{(?<name>[a-z]+)}", new GetRequestHandler(httpContext => new UserController().Details(httpContext.UrlParameters["name"])));
        }
    }
}
