using Sales.Migrations;
using Sales.Models;

namespace Sales
{
    using System.Data.Entity;

    public class SaleContext : DbContext
    {
        public SaleContext()
            : base("name=SaleContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SaleContext, Configuration>());
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
    }
}