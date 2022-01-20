using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
