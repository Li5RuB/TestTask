using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Task.Services.Models;
using Task.Services.Services;

namespace Task.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            UserModel userModel = await this.userService.GetById(1);
            return View(userModel);
        }
    }
}
