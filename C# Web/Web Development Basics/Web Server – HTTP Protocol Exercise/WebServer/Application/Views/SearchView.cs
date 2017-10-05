namespace WebServer.Application.Views
{
    using System;
    using System.Text;
    using WebServer.Server.Contracts;

    public class SearchView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"\\\">Back to home</a><br><br>")
                .AppendLine("<form method=\"post\">")
                .AppendLine("Name: <input type=\"text\" name=\"name\"/>")
                .AppendLine("<input type=\"submit\" value=\"Search\"/>")
                .AppendLine("</form>");

            if (this.SearchResult != null)
            {
                foreach (var cakeArg in this.SearchResult)
                {
                    string[] cake = cakeArg.Split('@', StringSplitOptions.RemoveEmptyEntries);
                    string name = cake[0];
                    string price = cake[1];
                    sb.AppendLine($"<div>name: {name}</div>");
                    sb.AppendLine($"<div>price: {price}</div>");
                }
            }

            return sb.ToString();
        }

        public string[] SearchResult { private get; set; }
    }
}
