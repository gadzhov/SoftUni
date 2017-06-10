using System;
using System.Linq;

namespace _2.Parse_URLs
{
    class Startup
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();
            if (url.Contains("://"))
            {
                var urlTokens = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
                var protocol = urlTokens[0];

                if (!urlTokens[1].Contains("/") || urlTokens[1].Contains("://"))
                {
                    Error();
                }
                else
                {
                    var index = urlTokens[1].IndexOf("/");
                    var server = urlTokens[1].Substring(0, index);
                    var resources = urlTokens[1].Substring(index + 1);

                    Console.WriteLine($"Protocol = {protocol}\nServer = {server}\nResources = {resources}");
                }
            }
            else
            {
                Error();
            }
        }

        private static void Error()
        {
            Console.WriteLine("Invalid URL");
        }
    }
}
