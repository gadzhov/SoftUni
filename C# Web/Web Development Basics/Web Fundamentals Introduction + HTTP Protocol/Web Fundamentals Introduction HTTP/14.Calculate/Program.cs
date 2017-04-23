using System;
using System.Net;

namespace _14.Calculate
{
    class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n</head>\r\n<body>\r\n    <form action=\"\" method=\"POST\">\r\n        <input type=\"text\" id=\"firstDigit\" name=\"firstDigit\">\r\n        <input type=\"text\" id=\"sign\" name=\"sign\">\r\n        <input type=\"text\" id=\"secondDigit\" name=\"secondDigit\">\r\n        <input type=\"submit\" value=\"Calculate\">\r\n    </form>\r\n</body>\r\n</html>");

            var inputData = Console.ReadLine().Split('&');
            try
            {
                var firstDigit = int.Parse(inputData[0].Split('=')[1]);
                var secondDigit = int.Parse(inputData[2].Split('=')[1]);
                var sign = WebUtility.UrlDecode(inputData[1].Split('=')[1]);

                switch (sign)
                {
                    case "+":
                        Console.WriteLine($"Result: {firstDigit + secondDigit}");
                        break;
                    case "-":
                        Console.WriteLine($"Result: {firstDigit - secondDigit}");
                        break;
                    case "*":
                        Console.WriteLine($"Result: {firstDigit * secondDigit}");
                        break;
                    case "/":
                        Console.WriteLine($"Result: {firstDigit / secondDigit}");
                        break;
                    default:
                        Console.WriteLine("Invalid sign!");break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
