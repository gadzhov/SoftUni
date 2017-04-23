
using ProductsShop.Migrations;
using ProductsShop.Models;

namespace ProductsShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopContext, Configuration>());
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Products)
                .WithMany(product => product.Categories)
                .Map(m =>
                {
                    m.MapLeftKey("Category_Id");
                    m.MapRightKey("Product_Id");
                    m.ToTable("CategoryProducts");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}