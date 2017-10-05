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
            appRouteConfig.AddRoute("/add", new GetRequestHandler(httpContext => new AddController().AddGet()));
            appRouteConfig.AddRoute("/add", new PostRequestHandler(httpContext => new AddController().AddPost(httpContext.FormData["name"], httpContext.FormData["price"])));
            appRouteConfig.AddRoute("/search", new GetRequestHandler(httpContext => new SearchController().SearchGet()));
            appRouteConfig.AddRoute("/search", new PostRequestHandler(httpContext => new SearchController().SearchPost(httpContext.FormData["name"])));
        }
    }
}
