namespace WebServer.Application.Views
{
    using System;
    using System.IO;
    using System.Text;
    using WebServer.Server.Contracts;

    public class AddView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"\\\">Back to home</a><br><br>")
                .AppendLine("<form method=\"post\">")
                .AppendLine("Name: <input type=\"text\" name=\"name\"/>")
                .AppendLine("Price: <input type=\"text\" name=\"price\"/>")
                .AppendLine("<input type=\"submit\" value=\"Add Cake\"/>")
                .AppendLine("</form>");

            string[] cakeArgs = File.ReadAllLines("cakes.txt");
            foreach (var cakeArg in cakeArgs)
            {
                string[] cake = cakeArg.Split('@', StringSplitOptions.RemoveEmptyEntries);
                string name = cake[0];
                string price = cake[1];
                sb.AppendLine($"<div>name: {name}</div>");
                sb.AppendLine($"<div>price: {price}</div>");
            }

            return sb.ToString();
        }
    }
}
