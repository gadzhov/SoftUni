namespace WebServer.Application.Controllers
{
    using System;
    using System.IO;
    using Server.Enums;
    using Server.Http.Response;
    using Views;

    public class AddController
    {
        public HttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new AddView());
        }

        public HttpResponse AddPost(string name, string price)
        {
            this.SaveToDb(name, price);

            return new RedirectResponse("\\add");
        }

        private void SaveToDb(string name, string price)
        {
            File.AppendAllText("cakes.txt", $"{name}@{price}" + Environment.NewLine);
        }
    }
}
