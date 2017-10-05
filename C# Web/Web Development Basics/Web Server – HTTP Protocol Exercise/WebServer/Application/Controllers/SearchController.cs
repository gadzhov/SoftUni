namespace WebServer.Application.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using WebServer.Application.Views;
    using WebServer.Server.Enums;
    using WebServer.Server.Http.Response;

    public class SearchController
    {
        public HttpResponse SearchGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new SearchView());
        }

        public HttpResponse SearchPost(string name)
        {
            string[] cakes = File.ReadAllLines("cakes.txt")
                .Where(c => Regex.IsMatch(c, name, RegexOptions.IgnoreCase))
                .ToArray();

            SearchView sv = new SearchView {SearchResult = cakes};

            return new ViewResponse(HttpStatusCode.Ok, sv);
        }
    }
}
