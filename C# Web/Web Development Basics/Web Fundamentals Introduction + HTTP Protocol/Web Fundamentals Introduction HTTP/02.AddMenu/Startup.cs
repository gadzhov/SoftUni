using System;

namespace _02.AddMenu
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");

            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\r\n    <h1>By the Cake</h1>\r\n    <h2>Enjoy our awesome cakes</h2>\r\n    <hr>\r\n    <ul>\r\n        <li>Home</li>\r\n        <ol>\r\n            <li>Our Cakes</li>\r\n            <li>Our Stores</li>\r\n        </ol>\r\n        <li>Add Cake</li>\r\n        <li>Browse Cake</li>\r\n        <li>About Us</li>\r\n    </ul>\r\n</body>\r\n</html>");
        }
    }
}
