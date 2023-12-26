using Assignment_4.Data;
using Assignment_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("about");
        }

        public IActionResult Work()
        {
            return View("work");
        }

        public IActionResult Category()
        {
            return View("category");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("login");
        }

        public IActionResult Signup()
        {
            var model = new Signup
            {
                Country = GetCountryList()
            };
            return View(model);
        }

        private List<string> GetCountryList()
        {
            return new List<string>
        {
            "Afghanistan", "South Africa", "Akrotiri", "Albania", "Germany", "Andorra", "Angola", "Anguilla", "Guinea"
        };
        }

        [HttpPost]
        public IActionResult Signup(WebsiteSignup signup)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Registration has been successfully completed.";
            }

            Data.Assingment4Context assingment4Context = new Data.Assingment4Context();

            assingment4Context.WebsiteSignups.Add(signup);
            assingment4Context.SaveChanges();

            return View("signup");
        }

        [HttpPost]
        public IActionResult Login(WebsiteSignup login)
        {
            Data.Assingment4Context assingment4Context = new Data.Assingment4Context();

            var status = assingment4Context.WebsiteSignups.Where(m => m.UserName == login.UserName && m.Password == login.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.assingment4Satus = 0;
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View("login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}