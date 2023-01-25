using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Interfaces;
using SportStore.Models.Pages;
using System.Runtime.InteropServices;

namespace SportStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;    

        public IEnumerable<Product> Products => context.Products
            .Include(p => p.Category)
            .ToArray();

        public PageList<Product> GetProducts(QueryOptions options)
        {
            return new PageList<Product>(context.Products.Include(p => p.Category), options);
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public Product GetProduct(int key) => context.Products
            .Include(p => p.Category)
            .First(p => p.Id == key);

        public void UpdateProduct(Product product)
        {
            Product p = context.Products.Find(product.Id);
            p.Name = product.Name;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            p.CategoryId = product.CategoryId;
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
