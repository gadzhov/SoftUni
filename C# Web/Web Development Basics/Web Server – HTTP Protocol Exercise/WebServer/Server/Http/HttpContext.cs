namespace WebServer.Server.Http
{
    using Http.Contracts;

    public class HttpContext : IHttpContext
    {
        public HttpContext(string requestStr)
        {
            this.HttpRequest = new HttpRequest(requestStr);
        }

        public IHttpRequest HttpRequest { get; }
    }
}
