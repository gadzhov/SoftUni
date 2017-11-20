namespace CameraBazaar.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Camera>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(builder);
        }
    }
}
