namespace WebServer.Server.Http.Response
{
    using Server.Contracts;
    using Enums;
    using global::WebServer.Server.Common;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse() 
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
