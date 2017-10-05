namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using Server.Handlers;
    using Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        private readonly List<string> parameters;

        public RoutingContext(RequestHandler requestHandler, List<string> args)
        {
            this.parameters = args;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters => this.parameters.AsReadOnly();

        public RequestHandler RequestHandler { get; }
    }
}
