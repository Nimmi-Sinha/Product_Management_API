using Product_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Product_Management_API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

      
        public DbSet<Products>? Product { get; set; }

        public DbSet<Category> Categories { get; set; }

        
    }
}
