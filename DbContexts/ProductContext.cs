using CourseWork.API.Models;

using Microsoft.EntityFrameworkCore;

namespace CourseWork.API.DbContexts
{
    public class ProductContext : DbContext
    {
        // Constructors DO NOT FORGET That Product Context class extends DB Context
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
              => Database.Migrate();
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
