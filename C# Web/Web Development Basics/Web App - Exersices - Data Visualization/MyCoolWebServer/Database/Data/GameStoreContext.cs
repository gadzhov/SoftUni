namespace MyCoolWebServer.Database.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.Database.Models;

    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=GameStore;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameOwner>()
                .HasKey(go => new {go.GameId, go.OwnerId});

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<GameOwner>()
                .HasOne(go => go.Game)
                .WithMany(g => g.Owners)
                .HasForeignKey(go => go.GameId);

            modelBuilder.Entity<GameOwner>()
                .HasOne(go => go.Owner)
                .WithMany(u => u.Games)
                .HasForeignKey(go => go.OwnerId);
        }
    }
}
