namespace WebServer
{
    using WebServer.Application;
    using WebServer.Server;
    using WebServer.Server.Contracts;
    using WebServer.Server.Routing;

    public class Launcher
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        private void Run()
        {
            IApplication app = new MainApplication();
            AppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}
