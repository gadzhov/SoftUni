namespace BankSystem.Data
{
    using BankSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class BankSystemContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public DbSet<SavingAccount> SavingAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=BankSystem;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
