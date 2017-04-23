namespace Local_Store
{
    using Local_Store.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreContext : DbContext
    {
       public StoreContext()
            : base("name=StoreContext")
        {
            Database.SetInitializer(new InitializerSeed());
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}