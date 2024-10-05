using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagerTest.Models;

namespace TaskManagerTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  // Return the Index view without needing ApplicationDbContext
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
