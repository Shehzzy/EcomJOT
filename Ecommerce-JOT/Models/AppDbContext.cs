using Microsoft.EntityFrameworkCore;

namespace Ecommerce_JOT.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Product> products { get; set; }
    }
}
