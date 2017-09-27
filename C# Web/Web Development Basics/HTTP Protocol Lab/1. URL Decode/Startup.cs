namespace _1._URL_Decode
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            string encodedUrl = Console.ReadLine();
            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            Console.WriteLine(decodedUrl);
        }
    }
}
