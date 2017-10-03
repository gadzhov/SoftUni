namespace WebServer.Server.Http.Response
{
    using Enums;
    using Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode responseCode, IView view) 
            : base(responseCode, view)
        {
        }
    }
}
