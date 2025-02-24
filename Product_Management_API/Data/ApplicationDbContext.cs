using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Product_Management_API.Models;

namespace Product_Management_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Products>? Product { get; set; }
    }
}
