using Microsoft.AspNetCore.Mvc;
using SportStore.Interfaces;
using SportStore.Models;
using SportStore.Models.Pages;
using System.Diagnostics.Eventing.Reader;

namespace SportStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository repo) => repository = repo;


        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetCategories(options));
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            repository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategory(long id)
        {
            ViewBag.EditId = id;
            return View("Index",repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            repository.Delete(category);
            return RedirectToAction(nameof(Index));
        }




    }
}
