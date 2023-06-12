using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppNew.Models;

namespace WebAppNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SaveSession()
        {
            HttpContext.Session.SetString("Name", "Computer");
            ViewBag.Name = "Computer";
            ViewData["Name"] = "Computer";
            return View();
        }
        public IActionResult RetriveSession()
        {
            string Name = HttpContext.Session.GetString("Name");
            return Content(Name);


        }
        public IActionResult createCookies()
        {
            
            Response.Cookies.Append("Name", "Computer");
            ViewBag.Name = "Computer";
            ViewData["Name"] = "Computer";
            return View();

        }
        public IActionResult readData()
        {
            var cookieValue = Request.Cookies["Name"];
            return Content(cookieValue);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}