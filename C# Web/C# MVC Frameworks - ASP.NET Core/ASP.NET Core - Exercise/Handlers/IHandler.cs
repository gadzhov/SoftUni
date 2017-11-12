namespace ASP.NET_Core___Exercise.Handlers
{
    using System;
    using Microsoft.AspNetCore.Http;

    public interface IHandler
    {
        int Order { get; }

        Func<HttpContext, bool> Condition { get; }

        RequestDelegate RequestHandler { get; }
    }
}
