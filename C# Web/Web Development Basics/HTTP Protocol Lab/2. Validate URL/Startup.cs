namespace _2._Validate_URL
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            string url = Console.ReadLine();
            string decodedUrl = WebUtility.HtmlDecode(url);

            try
            {
                Uri uri = new Uri(decodedUrl);
                string protocol = uri.Scheme;
                string host = uri.Host;
                int port = uri.Port;
                string path = uri.LocalPath;
                string queryString = uri.Query;
                string fragment = uri.Fragment;

                if (protocol != string.Empty && host != string.Empty && port != 0 && path != string.Empty)
                {
                    Console.WriteLine($"Protocol: {protocol}");
                    Console.WriteLine($"Host: {host}");
                    Console.WriteLine($"Port: {port}");
                    Console.WriteLine($"Path: {path}");
                    if (queryString != string.Empty)
                    {
                        Console.WriteLine($"Query: {queryString}");
                    }
                    if (fragment != string.Empty)
                    {
                        Console.WriteLine($"Fragment: {fragment}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid URL");
                }
            }
            catch
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
