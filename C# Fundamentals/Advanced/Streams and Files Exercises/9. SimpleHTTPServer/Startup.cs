using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace _9._SimpleHTTPServer
{
    class Startup
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var server = new TcpListener(IPAddress.Any, 1337);
                server.Start();
                Console.WriteLine("Wait for clients");
                using (TcpClient client = server.AcceptTcpClient())
                {
                    Console.WriteLine("Writing content");

                    string content = "Welcome to our testing page";
                    var writer = new StreamWriter(client.GetStream());
                    writer.Write("HTTP/1.0 200 OK");
                    writer.Write(Environment.NewLine);
                    writer.Write("Content-Type: text/plain; charset=UTF-8");
                    writer.Write(Environment.NewLine);
                    writer.Write("Content-Length: " + content.Length);
                    writer.Write(Environment.NewLine);
                    writer.Write(Environment.NewLine);
                    writer.Write(content);
                    writer.Flush();

                    Console.WriteLine("Disconnecting");
                    client.Close();
                    server.Stop();
                    Console.ReadKey();
                }
            }
        }
    }
}
