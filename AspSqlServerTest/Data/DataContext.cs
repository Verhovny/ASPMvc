using Microsoft.EntityFrameworkCore;
using AspSqLiteTest.Models;

namespace AspSqLiteTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):base(opts) { }
    
        public DbSet<Product> Products { get; set; }

    }
}
