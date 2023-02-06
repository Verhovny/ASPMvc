using ASPMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMvc.Data
{
    public class ProductContext : DbContext
    {
        /*
         Поставщика можно настроить, переопределив метод «DbContext.OnConfiguring» или
         используя «AddDbContext» в поставщике службы приложений.
         Если используется 'AddDbContext', также убедитесь, что ваш тип DbContext принимает объект 
         DbContextOptions<TContext> в своем конструкторе и передает его базовому конструктору для DbContext.
        */
        public ProductContext(DbContextOptions<ProductContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
