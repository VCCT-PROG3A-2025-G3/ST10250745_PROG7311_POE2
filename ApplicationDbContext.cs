using PROG7311POE2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROG7311POE2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
    }
}
