using Microsoft.AspNetCore.Mvc;
using SportStore.Interfaces;
using SportStore.Models;

namespace SportStore.Controllers
{
    [Route("api/products")]
    public class ProductValuesController : Controller
    {

        private IWebServiceRepository repository;
        
        public ProductValuesController(IWebServiceRepository repo)
        {
            repository = repo;
        }

        [HttpGet("{id}")]
        public object GetProduct(long id)
        {
            return repository.GetProduct(id) ?? NotFound();
        }

        public object Products(int skip, int take)
        {
            return repository.GetProducts(skip, take);
        }

        [HttpPost]
        public long StoreProduct([FromBody] Product product)
        {
            return repository.StoreProduct(product);
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
           repository.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
        }


    }
}
