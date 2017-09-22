namespace _5._Shop_Hierarchy.Data
{
    using Microsoft.EntityFrameworkCore;
    using _5._Shop_Hierarchy.Models;

    public class Entity : DbContext
    {
        public DbSet<Salesmen> Salesmens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ItemsOrders> ItemsOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=TestDb;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Salesmen)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.SalesmenId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<ItemsOrders>()
                .HasKey(io => new { io.ItemId, io.OrderId });

            modelBuilder.Entity<ItemsOrders>()
                .HasOne(io => io.Item)
                .WithMany(i => i.Orders)
                .HasForeignKey(io => io.ItemId);

            modelBuilder.Entity<ItemsOrders>()
                .HasOne(io => io.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(io => io.OrderId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Reviews)
                .WithOne(r => r.Item)
                .HasForeignKey(r => r.ItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}