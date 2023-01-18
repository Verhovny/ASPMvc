using SportStore.Data;
using SportStore.Interfaces;
using System.Runtime.InteropServices;

namespace SportStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;    

        public IEnumerable<Product> Products => context.Products.ToArray();

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public Product GetProduct(int key) => context.Products.Find(key);

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void Delete(Product product) 
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }


        // Можно реализовать обновление множества продуктов с помощью метода UpdateAll

    }
}
