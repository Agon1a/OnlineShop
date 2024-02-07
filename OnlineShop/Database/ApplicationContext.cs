using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
