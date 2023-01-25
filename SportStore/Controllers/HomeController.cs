using Microsoft.AspNetCore.Mvc;
using SportStore.Interfaces;
using SportStore.Models;
using SportStore.Models.Pages;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ICategoryRepository categoryRepository;
        public HomeController(IRepository repo, ICategoryRepository catRepo)
        {
            repository = repo;
            categoryRepository = catRepo;
        }

        public IActionResult Index(QueryOptions options)
        {
            //System.Console.Clear();
            return View(repository.GetProducts(options));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProduct(int key)
        {
            ViewBag.Categories = categoryRepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }


        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if(product.Id == 0)
            {
                repository.AddProduct(product);
            }
            else
            {
                repository.UpdateProduct(product);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
