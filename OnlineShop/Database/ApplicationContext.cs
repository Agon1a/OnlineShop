using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.DBModels;

namespace OnlineShop.Database
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u => u.Bonuses).HasDefaultValue(0);
            modelBuilder.Entity<UserAddress>().Property(ua => ua.AddressId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<ShoppingCart>().Property(s => s.ProductsJson).HasDefaultValue("{[]}");
            modelBuilder.Entity<ShoppingCart>().Property(s => s.CartId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Order>().Property(o => o.OrderId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).HasDefaultValueSql("NEWID()");
        }
    }
}
