using SportStore.Models;

namespace SportStore.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get;  }
        void AddProduct(Product product);

        Product GetProduct(int key);

        void UpdateProduct(Product product);
    }
}
