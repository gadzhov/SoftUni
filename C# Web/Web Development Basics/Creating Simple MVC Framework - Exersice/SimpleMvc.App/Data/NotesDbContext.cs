namespace SimpleMvc.App.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.App.Models;

    public class NotesDbContext : DbContext
    {
        private static bool isCreated = false;

        public NotesDbContext()
        {
            if (!isCreated)
            {
                this.Database.EnsureCreated();
                isCreated = true;
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
