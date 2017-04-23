using Data.Migrations;
using Models;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BusTicketContext : DbContext
    {
        public BusTicketContext()
            : base("name=BusTicketContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BusTicketContext, Configuration>());
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BusCompany> BusCompanies { get; set; }
        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOptional(c => c.BankAccount)
                .WithRequired(b => b.Customer);


            base.OnModelCreating(modelBuilder);
        }
    }
}