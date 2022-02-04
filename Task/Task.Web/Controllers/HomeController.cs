using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Test(Dictionary<string, string> sort)
        {
            Method(sort);
            return RedirectToAction("Index");
        }

        private void Method(Dictionary<string, string> sort)
        {
            Console.WriteLine(sort.Count);
        }
    }
}
