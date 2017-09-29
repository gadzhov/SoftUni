namespace _3._Simple_Web_Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            const int port = 1300;
            TcpListener listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients on 127.0.0.1:{port}");

            Task.Run(async () => await ConnectWithTcpClient(listener))
                .GetAwaiter()
                .GetResult();
        }

        private static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                TcpClient client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                // Read the request and print it on the console.
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);

                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message.Trim('\0'));

                // Send a greeting to the client.
                string response = "HTTP/1.1 200 OK" + Environment.NewLine;
                response += "Content-Type: text/html" + Environment.NewLine + Environment.NewLine;
                response += "Hello from server!";
                byte[] data = Encoding.ASCII.GetBytes(response);
                client.GetStream().Write(data, 0, data.Length);

                // Close the connection.Close the connection.
                Console.WriteLine("Closing connection");
                client.GetStream().Dispose();
            }
        }
    }
}
