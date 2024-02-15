using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Database
{
    public class ApplicationContext : DbContext
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
            modelBuilder.Entity<User>().Property(u => u.Bonuses).HasDefaultValue(0);
            modelBuilder.Entity<ShoppingCart>().Property(s => s.ProductsJson).HasDefaultValue("{[]}");
        }
    }
}
