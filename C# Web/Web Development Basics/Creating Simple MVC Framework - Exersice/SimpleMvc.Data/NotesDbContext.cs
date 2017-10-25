namespace SimpleMvc.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Domain;

    public class NotesDbContext : DbContext
    {
        public static void Initialize()
        {
            using (NotesDbContext context = new NotesDbContext())
            {
                Console.WriteLine("Initializing the db...");
                context.Database.EnsureCreated();
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=NoteApp;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.Owner)
                .HasForeignKey(n => n.OwnerId);
        }
    }
}
