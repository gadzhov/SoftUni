namespace WebServer.Application.Controllers
{
    using WebServer.Application.Views;
    using WebServer.Server;
    using WebServer.Server.Enums;
    using WebServer.Server.Http.Response;

    public class UserController
    {
        public HttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new RegisterView());
        }

        public HttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public HttpResponse Details(string name)
        {
            Model model = new Model{ ["name"] = name };

            return new ViewResponse(HttpStatusCode.Ok, new UserDetailslView(model));
        }
    }
}
