using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Interfaces;

namespace SportStore.Models
{
    public class WebServiceRepository : IWebServiceRepository
    {
        private DataContext context;

        public WebServiceRepository(DataContext ctx) => context = ctx;

        public object GetProduct(long id)
        {

            // связанные данные null
            //return context.Products.FirstOrDefault(p => p.Id == id);

            // связанные данные включены
            //return context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);

            /* чистый
            return context.Products.Select(p => 
            new
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PurchasePrice = p.PurchasePrice,
                RetailPrice = p.RetailPrice
            }).FirstOrDefault(p => p.Id == id);
            */
            

            return context.Products.Include(p => p.Category).Select(p =>
            new
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PurchasePrice = p.PurchasePrice,
                RetailPrice = p.RetailPrice,
                CategoryId = p.CategoryId,
                Category = new
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Description = p.Category.Description
                }
            }).FirstOrDefault(p => p.Id == id);

        }



        public object GetProducts(int skip, int take)
        {
            return context.Products.Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasePrice = p.PurchasePrice,
                    Description = p.Description,
                    RetailPrice = p.RetailPrice,
                    CategoryId = p.CategoryId,
                    Category = new
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Desctiption = p.Category.Description
                    }

                });
;       }

        public long StoreProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            context.Products.Remove(new Product { Id = id });
            context.SaveChanges();
        }



    }
}
