namespace WebServer.Application.Views
{
    using WebServer.Server;
    using WebServer.Server.Contracts;

    public class UserDetailslView : IView
    {
        private readonly Model model;

        public UserDetailslView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {this.model["name"]}!</body>";
        }
    }
}
