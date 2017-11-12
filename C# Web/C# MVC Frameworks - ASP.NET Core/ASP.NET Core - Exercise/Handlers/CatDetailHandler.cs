namespace ASP.NET_Core___Exercise.Handlers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class CatDetailHandler : IHandler
    {
        public int Order => 3;

        public Func<HttpContext, bool> Condition
            => ctx => ctx.Request.Path.Value.StartsWith("/cat") && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler
            => async (context) =>
            {
                CatsDbContext db = context.RequestServices.GetRequiredService<CatsDbContext>();
                string[] requestParts = context.Request.Path.Value.Split("/");

                if (requestParts.Length < 2)
                {
                    context.Response.Redirect("/");
                }

                int.TryParse(requestParts[2], out int id);
                if (id == 0)
                {
                    context.Response.Redirect("/");
                }

                Cat cat = await db.Cats.FindAsync(id);
                if (cat == null)
                {
                    context.Response.Redirect("/");
                }

                await context.Response.WriteAsync($"<h1>{cat.Name}<h1>");
                await context.Response.WriteAsync(
                    $@"<image src=""{cat.ImageUrl}"" width=""200"" alt=""{cat.Name}"" >");
                await context.Response.WriteAsync($"<p><bold>Age: {cat.Age}</bold></p>");
                await context.Response.WriteAsync($"<p><bold>Breed: {cat.Breed}</bold></p>");
            };
    }
}
