using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Summary of Qualifications:";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "My Contact Page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
