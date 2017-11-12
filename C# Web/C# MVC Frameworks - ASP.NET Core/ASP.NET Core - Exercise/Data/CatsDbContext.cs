namespace ASP.NET_Core___Exercise
{
    using Microsoft.EntityFrameworkCore;

    public class CatsDbContext : DbContext
    {
        public CatsDbContext(DbContextOptions<CatsDbContext> options)
            : base (options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
