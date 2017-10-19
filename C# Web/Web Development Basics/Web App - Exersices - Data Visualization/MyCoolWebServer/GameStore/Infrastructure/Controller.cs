namespace MyCoolWebServer.GameStore.Infrastructure
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MyCoolWebServer.GameStore.Security;
    using MyCoolWebServer.Server.Http;
    using Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class Controller
    {
        private const string DefaultPath = @"GameStore\Resources\{0}.html";
        private const string ContentPlaceHolder = @"{{{content}}}";

        protected Controller(IHttpRequest req)
        {
            this.ViewData = new Dictionary<string, string>();
            this.Request = req;
        }

        protected IHttpRequest Request { get; private set; }

        protected Dictionary<string, string> ViewData { get; set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            string result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            this.ViewData["admin-display"] = "none";
            this.ViewData["login-display"] = "block";
            this.ViewData["register-display"] = "block";
            this.ViewData["logout-display"] = "none";

            string layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));
            string fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            string result = layoutHtml.Replace(ContentPlaceHolder, fileHtml);

            Authorization auth = this.Request.Session.Get<Authorization>(SessionStore.CurrentUserAuthorization);

            if (auth != null)
            {
                if (!auth.IsAdmin)
                {
                    this.ViewData["admin-display}"] = "none";
                }
                else
                {
                    this.ViewData["admin-display"] = "block";
                }

                this.ViewData["login-display"] = "none";
                this.ViewData["register-display"] = "none";
                this.ViewData["logout-display"] = "block";
            }

            if (this.ViewData.Any())
            {
                foreach (KeyValuePair<string, string> kvp in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{kvp.Key}}}}}}}", kvp.Value);
                }
            }

            return result;
        }
    }
}
