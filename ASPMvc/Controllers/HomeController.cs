using ASPMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                return View("Thanks", response);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListResponses()
        {
            return View(Repository.Responses.Where(g => g.WillAttendant == true));
        }

    }
}