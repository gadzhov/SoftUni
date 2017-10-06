namespace WebServer.Application.Controllers
{
    using System;
    using System.Globalization;
    using System.IO;
    using WebServer.Application.Views;
    using WebServer.Server.Enums;
    using WebServer.Server.Http.Response;

    public class CalculatorController
    {
        public HttpResponse CalculatorGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new CalculatorView());
        }

        public HttpResponse CalculatorPost(string numberOne, string symbol, string numberTwo)
        {
            double result = 0;
            if (symbol == "+")
            {
                result = double.Parse(numberOne) + double.Parse(numberTwo);
            }
            else if (symbol == "-")
            {
                result = double.Parse(numberOne) - double.Parse(numberTwo);

            }
            else if (symbol == "*")
            {
                result = double.Parse(numberOne) * double.Parse(numberTwo);

            }
            else if (symbol == "/")
            {
                result = double.Parse(numberOne) / double.Parse(numberTwo);

            }

            File.AppendAllText("calculator.txt", result.ToString(CultureInfo.InvariantCulture) + Environment.NewLine);

            return new ViewResponse(HttpStatusCode.Ok, new CalculatorView());
        }
    }
}
