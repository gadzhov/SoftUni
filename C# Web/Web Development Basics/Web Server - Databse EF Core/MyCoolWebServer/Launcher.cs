namespace MyCoolWebServer
{
    using ByTheCakeApplication;
    using MyCoolWebServer.Database.Data;
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
            CakeContext context = new CakeContext();
            context.Database.EnsureCreated();

            var mainApplication = new ByTheCakeApp();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
