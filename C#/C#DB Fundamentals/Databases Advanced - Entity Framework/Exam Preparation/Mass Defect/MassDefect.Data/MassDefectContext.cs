using MassDefect.Models;

namespace MassDefect.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(p => p.OriginalAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(p => p.TargetAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planet>()
                .HasRequired(p => p.Sun)
                .WithMany(s => s.Planets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasMany(a => a.Victims)
                .WithMany(v => v.Anomalies)
                .Map(map =>
                {
                    map.MapLeftKey("AnomalyId");
                    map.MapRightKey("PersonId");
                    map.ToTable("AnomalyVictims");
                });
        }

        public virtual DbSet<Anomaly> Anomalies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
    }
}