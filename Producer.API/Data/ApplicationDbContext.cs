using Microsoft.EntityFrameworkCore;
using Producer.API.Models;

namespace Producer.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        
        }

        public DbSet<Product> Products { get; set; }
    }
}
    