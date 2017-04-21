using System;
using System.IO;
using System.Linq;

namespace _13.BrowseCakes
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\r\n    <form action=\"\" method=\"GET\">\r\n        <input type=\"text\" id=\"search\" name=\"search\">\r\n        <input type=\"submit\" value=\"Search\">\r\n    </form>\r\n</body>\r\n</html>");

            var queryEnvironmentVariable = Environment.GetEnvironmentVariable("QUERY_STRING");
            var search = queryEnvironmentVariable.Split('=')[1];

            var text = File.ReadAllLines("database.csv");
            var filtered = text.Where(t => t.Contains(search));

            foreach (var item in filtered)
            {
                Console.WriteLine("<p>");
                Console.WriteLine(item);
                Console.WriteLine("</p>");
            }
        }
    }
}
