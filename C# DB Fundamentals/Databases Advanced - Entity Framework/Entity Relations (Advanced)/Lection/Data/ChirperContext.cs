using Lection.ModelConfiguration;

namespace Lection.Data
{
    using Lection.Models;
    using System.Data.Entity;

    public class ChirperContext : DbContext
    {
        public ChirperContext()
            : base("name=ChirperContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Chirp> Chirps { get; set; }
        public virtual DbSet<ChImg> ChImgs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ChirpConfiguration());
            modelBuilder.Configurations.Add(new ChImgConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());

            modelBuilder.Entity<Person>()
                .HasOptional(p => p.PlaceOfBirth)
                .WithMany(t => t.Natives)
                .HasForeignKey(t => t.PlaceOfBirthId);

            modelBuilder.Entity<Person>()
                .HasOptional(p => p.CurrentResidence)
                .WithMany(t => t.Residents)
                .HasForeignKey(p => p.CurrentResidenceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}