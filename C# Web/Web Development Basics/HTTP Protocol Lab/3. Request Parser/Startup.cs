namespace _3._Request_Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            List<string> paths = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                paths.Add(input);
            }

            string[] request = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string method = request[0];
            string url = request[1];
            string requestPath = $"{url}/{method.ToLower()}";
            bool isValid = paths.Any(p => p == requestPath);

            int statusCode = isValid ? (int) HttpStatusCode.OK : (int) HttpStatusCode.NotFound;
            string content = isValid ? HttpStatusCode.OK.ToString() : HttpStatusCode.NotFound.ToString();
            int contentLength = content.Length;

            Console.WriteLine($"HTTP/1.1 {statusCode} {content}");
            Console.WriteLine($"Content-Length: {contentLength}");
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(content);
        }
    }
}
