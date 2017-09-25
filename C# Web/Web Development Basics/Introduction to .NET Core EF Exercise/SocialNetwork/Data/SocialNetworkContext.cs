namespace SocialNetwork.Data
{
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Models;

    public class SocialNetworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=SocialNetwork;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Self-reference many-to-many
            modelBuilder.Entity<UserFriends>()
                .HasKey(uf => new { uf.UserId, uf.FriendId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithOne(uf => uf.User)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-many
            modelBuilder.Entity<AlbumPictures>()
                .HasKey(ap => new {ap.AlbumId, ap.PictureId});

            modelBuilder.Entity<AlbumPictures>()
                .HasOne(ap => ap.Album)
                .WithMany(a => a.Pictures)
                .HasForeignKey(ap => ap.AlbumId);

            modelBuilder.Entity<AlbumPictures>()
                .HasOne(ap => ap.Picture)
                .WithMany(p => p.Albums)
                .HasForeignKey(ap => ap.PictureId);

            // One-to-many
            modelBuilder.Entity<User>()
                .HasMany(u => u.AlbumsOwned)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId);

            // Many-to-many
            modelBuilder.Entity<AlbumTags>()
                .HasKey(at => new {at.AlbumId, at.TagId});

            modelBuilder.Entity<AlbumTags>()
                .HasOne(at => at.Album)
                .WithMany(a => a.Tags)
                .HasForeignKey(at => at.AlbumId);

            modelBuilder.Entity<AlbumTags>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.Albums)
                .HasForeignKey(at => at.TagId);

            // Many-to-many
            modelBuilder.Entity<AlbumParticipates>()
                .HasKey(ap => new {ap.AlbumId, ap.UserId});

            modelBuilder.Entity<AlbumParticipates>()
                .HasOne(ap => ap.Album)
                .WithMany(a => a.Participants)
                .HasForeignKey(ap => ap.AlbumId);

            modelBuilder.Entity<AlbumParticipates>()
                .HasOne(ap => ap.User)
                .WithMany(u => u.AlbumsParticipate)
                .HasForeignKey(ap => ap.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
