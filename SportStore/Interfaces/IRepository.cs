using SportStore.Models;
using SportStore.Models.Pages;

namespace SportStore.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get;  }

        PageList<Product> GetProducts(QueryOptions options, long category = 0);

        void AddProduct(Product product);

        PageList<Product> GetProducts(QueryOptions options);
        Product GetProduct(int key);

        void UpdateProduct(Product product);

        void Delete(Product product);

    }
}
