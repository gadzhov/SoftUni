namespace MyCoolWebServer
{
    using MyCoolWebServer.Database.Data;
    using MyCoolWebServer.GameStore;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            using (GameStoreContext context = new GameStoreContext())
            {
                context.Database.EnsureCreated();
            }
            
            var mainApplication = new GameStoreApp();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
