namespace WebServer.Server.Handlers
{
    using System;
    using Contracts;
    using global::WebServer.Server.Http;
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
            this.SetCookies(httpContext, httpResponse);

            return httpResponse;
        }

        private void SetCookies(
            IHttpContext httpContext, IHttpResponse httpResponse)
        {
            HttpSession session = default(HttpSession);
            var cookies = httpContext.HttpRequest.CookieCollection;
            foreach (HttpCookie cookie in cookies)
                if (cookie.IsNew)
                {
                    session = httpContext.HttpRequest.HttpSession;
                    if (!cookies.ContainsKey("SID") || session == null)
                    {
                        string sessionId = SessionCreator
                            .GetInstance().GenerateSessionId();

                        httpResponse.AddHeader("Set-Cookie", "sessionId=" + sessionId + "; HttpOnly; path=/");

                        HttpSession httpSession = new HttpSession(sessionId);
                        httpContext.HttpRequest.HttpSession = httpSession;

                    }
                    else
                    {
                        // Parse the cookie }


                        httpResponse.AddHeader("Set-Cookie",
                            cookie.ToString());
                    }
                }
            if (session == null)
            {
                session = httpContext.HttpRequest.HttpSession;
                if (!cookies.ContainsKey("SID") || session == null)
                {
                    string sessionId = SessionCreator
                        .GetInstance().GenerateSessionId();

                    httpResponse.AddHeader("Set-Cookie", "sessionId=" + sessionId + "; HttpOnly; path=/");

                    HttpSession httpSession = new HttpSession(sessionId);
                    httpContext.HttpRequest.HttpSession = httpSession;

                }
            }
        }

    }
}
