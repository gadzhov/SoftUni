namespace ASP.NET_Core___Exercise.Handlers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class HomeHandler : IHandler
    {
        private const string AppName = "CatApp";
        
        public int Order => 1;

        public Func<HttpContext, bool> Condition => ctx =>
            ctx.Request.Path.Value == "/" && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler => async (context) =>
        {
            await context.Response.WriteAsync($"<h1>{AppName}</h1>");

            CatsDbContext db = context.RequestServices.GetRequiredService<CatsDbContext>();

            var catData = db.Cats.Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .ToList();

            await context.Response.WriteAsync("<ul>");

            foreach (var cat in catData)
            {
                await context.Response.WriteAsync($@"<li><a href=""\cat\{cat.Id}"">{cat.Id}-{cat.Name}</a></li>");
            }

            await context.Response.WriteAsync("</ul>");
            await context.Response.WriteAsync(@"
                            <form action=""/cat/add"">
                                <input type=""submit"" value=""Add Cat"" />
                            </form>");
        };
    }
}
