using TeamBiulder.Data.Configurations;
using TeamBiulder.Models;

namespace TeamBiulder.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBiulderContext : DbContext
    {
        public TeamBiulderContext()
            : base("name=TeamBiulderContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TeamBiulderContext>());
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}