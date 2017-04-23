using System;

namespace _11.AddCake
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine(
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\r\n    <form action=\"\" method=\"POST\">\r\n        <label for=\"name\">Name:</label>\r\n        <input type=\"text\" id=\"name\" name=\"cakeName\">\r\n        <label for=\"price\">Price:</label>\r\n        <input type=\"text\" id=\"price\" name=\"cakePrice\">\r\n        <input type=\"submit\" value=\"Submit\">\r\n    </form>\r\n</body>\r\n</html>");

            var data = Console.ReadLine();
            var array = data.Split('&');
            var cakeName = array[0].Split('=')[1];
            var cakePrice = array[1].Split('=')[1];
            Console.WriteLine("name: " + cakeName);
            Console.WriteLine("<br>");
            Console.WriteLine("price: " + cakePrice);
        }
    }
}
