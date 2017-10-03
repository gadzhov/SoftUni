namespace WebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Handlers;
    using Http;
    using Http.Contracts;
    using Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string request = await this.ReadRequest();
            IHttpContext htpContext = new HttpContext(request);
            IHttpResponse httpResponse = new HttpHandler(this.serverRouteConfig).Handle(htpContext);
            ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(httpResponse.Response));

            await this.client.SendAsync(toBytes, SocketFlags.None);

            Console.WriteLine(request);
            Console.WriteLine(httpResponse.Response);

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;
            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            int numBytesRead;

            while ((numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None)) > 0)
            {
                request += Encoding.ASCII.GetString(data.Array, 0, numBytesRead);
                if (numBytesRead < 1023) break;
            }

            return request;
        }
    }
}
