using Lection.Migrations;
using Lection.Models;

namespace Lection
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=MovieContext")
        {
            // SetInitializer to the Seed
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieContext, Configuration>());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}