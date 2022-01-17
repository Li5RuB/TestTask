using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Task.Services.Models;
using Task.Services.Services;

namespace Task.Web.Controllers
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
    }
}
