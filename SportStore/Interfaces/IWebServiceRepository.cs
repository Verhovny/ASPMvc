using SportStore.Models;

namespace SportStore.Interfaces
{
    public interface IWebServiceRepository
    {
        object GetProduct(long id);

        object GetProducts(int skip, int take);

        long StoreProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
    