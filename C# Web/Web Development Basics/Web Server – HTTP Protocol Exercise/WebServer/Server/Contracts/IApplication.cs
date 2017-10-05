namespace WebServer.Server.Contracts
{
    using global::WebServer.Server.Routing.Contracts;

    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}
