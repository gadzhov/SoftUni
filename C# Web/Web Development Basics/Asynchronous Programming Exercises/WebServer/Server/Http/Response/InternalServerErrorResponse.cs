namespace WebServer.Server.Http.Response
{
    using System;
    using Enums;
    using global::WebServer.Server.Common;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception e) 
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(e))
        {
        }
    }
}
