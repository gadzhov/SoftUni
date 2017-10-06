namespace WebServer.Application.Views
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using WebServer.Server.Contracts;

    public class CalculatorView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"\\\">Back to home</a><br><br>")
                .AppendLine("<form method=\"post\">")
                .AppendLine("<input type=\"number\" name=\"numberOne\">")
                .AppendLine("<input type=\"text\" name=\"symbol\">")
                .AppendLine("<input type=\"number\" name=\"numberTwo\">")
                .AppendLine("<input type=\"submit\" name=\"calculate\" value=\"Calculate\">")
                .AppendLine("</form>");

            string[] numbers = File.ReadAllLines("calculator.txt");

            foreach (var number in numbers)
            {
                sb.AppendLine($"<div>Result: {number}</div>");
            }

            return sb.ToString();
        }
    }
}
