using System;

namespace _15.LoginForm
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n\r\n<body>\r\n    <form action=\"\" method=\"POST\">\r\n        <label for=\"username\">Username</label>\r\n        <input type=\"text\" id=\"username\" name=\"username\">\r\n        <br>\r\n        <lebel for=\"password\">Password</lebel>\r\n        <input type=\"password\" id=\"password\" name=\"password\">\r\n        <br>\r\n        <input type=\"submit\" value=\"Log in\">\r\n    </form>\r\n</body>\r\n\r\n</html>");

            var data = Console.ReadLine().Split('&');
            var name = data[0].Split('=')[1];
            var password = data[1].Split('=')[1];

            Console.WriteLine($"Hi {name}, your password is {password}");
        }
    }
}
