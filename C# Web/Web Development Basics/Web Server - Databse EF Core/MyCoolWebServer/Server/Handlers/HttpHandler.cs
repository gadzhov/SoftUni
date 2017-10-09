namespace MyCoolWebServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http.Contracts;
    using Http.Response;
    using Routing.Contracts;
    using System;
    using System.Text.RegularExpressions;
    using Server.Http;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            try
            {
                // redirect to login first
                const string loginPage = "/login";
                const string registerPage = "/register";

                if (!context.Request.Session.Contains(SessionStore.CurrentUserKey) && context.Request.Path != loginPage && context.Request.Path != registerPage)
                {
                    return new RedirectResponse("login");
                }

                // prevent login again
                if (context.Request.Session.Contains(SessionStore.CurrentUserKey) && context.Request.Path == loginPage)
                {
                    return new RedirectResponse("/");
                }

                // prevent register if logged in
                if (context.Request.Session.Contains(SessionStore.CurrentUserKey) && context.Request.Path == registerPage)
                {
                    return new RedirectResponse("/");
                }

                var requestMethod = context.Request.Method;
                var requestPath = context.Request.Path;
                var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

                foreach (var registeredRoute in registeredRoutes)
                {
                    var routePattern = registeredRoute.Key;
                    var routingContext = registeredRoute.Value;

                    var routeRegex = new Regex(routePattern);
                    var match = routeRegex.Match(requestPath);

                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameters = routingContext.Parameters;

                    foreach (var parameter in parameters)
                    {
                        var parameterValue = match.Groups[parameter].Value;
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }
    }
}
