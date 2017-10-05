namespace WebServer.Server.Http.Contracts
{
    public interface IHttpResponse
    {
        string Response { get; }

        void AddHeader(string key, string value);
    }
}
