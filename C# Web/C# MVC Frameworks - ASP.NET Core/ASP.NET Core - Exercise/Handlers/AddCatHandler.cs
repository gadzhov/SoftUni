namespace ASP.NET_Core___Exercise.Handlers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class AddCatHandler : IHandler
    {
        public int Order => 2;

        public Func<HttpContext, bool> Condition 
            => ctx => ctx.Request.Path == "/cat/add";

        public RequestDelegate RequestHandler
            => async context =>
            {
                if (context.Request.Method == HttpMethod.Get)
                {
                    context.Response.Redirect("/cats-add-form.html");
                }
                else if (context.Request.Method == HttpMethod.Post)
                {
                    if (context.Request.HasFormContentType)
                    {
                        CatsDbContext db = context.RequestServices.GetRequiredService<CatsDbContext>();

                        IFormCollection formData = context.Request.Form;

                        Cat cat = new Cat
                        {
                            Name = formData["Name"],
                            Age = int.Parse(formData["Age"]),
                            Breed = formData["Breed"],
                            ImageUrl = formData["ImageUrl"]
                        };

                        db.Cats.Add(cat);

                        try
                        {
                            await db.SaveChangesAsync();

                            context.Response.Redirect("/");
                        }
                        catch
                        {
                            await context.Response.WriteAsync("<h2>Invalid cat data!</h2>");
                            await context.Response.WriteAsync(@"<a href=""/cat/add"">Back to form</a>");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = HttpStatusCode.Found;
                        context.Response.Headers.Add(HttpHeader.Location, "/cats-add-form.html");
                    }
                }
            };
    }
}
