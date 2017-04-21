using System;

namespace _01.FirstWebSite
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");

            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>First Web Site</title>\r\n</head>\r\n<body>\r\n    <h1>By the Cake</h1>\r\n    <h2>Enjoy our awesome cakes</h2>\r\n    <hr>\r\n</body>\r\n</html>");
        }
    }
}
