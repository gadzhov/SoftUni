using System.Collections.Generic;
using Lection.Models;

namespace Lection.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lection.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Lection.MovieContext";
        }

        protected override void Seed(Lection.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var defaultMovies = new List<Movie>
            {
                new Movie() {Title = "The Flash", ReleaseYear = 2014, Rate = 9.1f, Duration = 40},
                new Movie() {Title = "Arrow", ReleaseYear = 2012, Rate = 9.0f, Duration = 45}
            };
            foreach (var movie in defaultMovies)
            {
                context.Movies.Add(movie);
            }
            base.Seed(context);
        }
    }
}
