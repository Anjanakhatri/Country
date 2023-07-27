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
        //session
        public IActionResult Index()
        {
            TempData["Id"] = 110;
            HttpContext.Session.SetString("Name", "Anjana");
            HttpContext.Session.SetInt32("Age", 23);
            return View();
        }
        public IActionResult Get()
        {
            User user = new User()
            {
                name=HttpContext.Session.GetString("Name"),
                age=HttpContext.Session.GetInt32("Age").Value
            };
            ViewBag.message = user;
            return View();
        }
        //tempdata
        public IActionResult First()
        
        {
            var Id = TempData["Id"];
            TempData.Keep();
            return View();
        }
        public IActionResult Second()
        {
            var Id = TempData["Id"];
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
            
            Response.Cookies.Append("Name", "Computers");
            ViewBag.Name = "Computers";
            ViewData["Name"] = "Computers";
            return View();

        }
        public IActionResult readData()
        {
            var cookieValue = Request.Cookies["Name"];
            return Content(cookieValue);
        }
        // Inside a controller action method or middleware
        public IActionResult SetCookie()
        {
            // Creating a new cookie
            Response.Cookies.Append("MyCookie", "Hello, this is my cookie value!");

            // You can also set additional options like expiration, domain, and path
            // Example with expiration time:
            Response.Cookies.Append("MyCookieWithExpiration", "Cookie with expiration", new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(30)// Cookie will expire after 1 day
            });

            return RedirectToAction("Index");
        }
        // Inside a controller action method or middleware
        public IActionResult GetCookie()
        {
            string myCookieValue = Request.Cookies["MyCookie"];

            if (myCookieValue != null)
            {
                // Do something with the cookie value
                // For example, pass it to the view
                ViewBag.MyCookieValue = myCookieValue;
            }

            return View();
        }
        // Inside a controller action method or middleware
        public IActionResult DeleteCookie()
        {
            // Deleting the cookie by setting its expiration to a past date
            Response.Cookies.Append("MyCookie", "", new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(-30) // Setting an expiration in the past removes the cookie
            });

            return RedirectToAction("Index");
        }

        //Query string
        public IActionResult GetQueryString(string Name,int Age)
        {
            User newuser = new User()
            {
                name = Name,
                age = Age
            };
            return View(newuser);
        }
        //hidden fields
        public IActionResult HiddenFieldEx()
        {
           ViewBag.newstudent = new Student()
            {
               Id=12,
                name = "Anjana",
                age = 20
            };
            return View();
        }

        [HttpPost]
        public IActionResult HiddenFieldEx(Student std)
        {
            var Id = std.Id;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}