namespace WebServer.Server.Handlers
{
    using System;
    using Contracts;
    using Server.Http.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> func;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func.Invoke(httpContext.HttpRequest);
            httpResponse.AddHeader("Content-Type", "text-html");

            return httpResponse;
        }
    }
}
