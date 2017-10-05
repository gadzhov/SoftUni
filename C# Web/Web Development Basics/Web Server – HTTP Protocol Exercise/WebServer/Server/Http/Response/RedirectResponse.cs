namespace WebServer.Server.Http.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl) 
            : base(redirectUrl)
        {
        }
    }
}
