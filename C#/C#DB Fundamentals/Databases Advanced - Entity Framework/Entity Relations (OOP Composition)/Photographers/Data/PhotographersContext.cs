using Photographers.Migrations;
using Photographers.Models;

namespace Photographers.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographersContext : DbContext
    {
       public PhotographersContext()
            : base("name=PhotographersContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographersContext, Configuration>());
        }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
    }
}