using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Task.Services.Models;
using Task.Services.Services;

namespace Task.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ICountryService countryService;
        private readonly ITitleService titleService;
        private readonly ICityService cityService;
        
        public UsersController(IUserService userService, ITitleService titleService, ICountryService countryService, ICityService cityService)
        {
            this.userService = userService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.titleService = titleService;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var users = search == null ? userService.GetByPage(page) : userService.Search(search , page);
            var pageCount = userService.GetPageCount(search);
            if (pageCount < page)
                page = 1;
            else if (page < 1)
                page = pageCount;
            ViewData["page"] = page;
            ViewData["pcount"] = pageCount;
            ViewData["search"] = search;
            return View(await userService.GetAllUserFields(users.ToList()));
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var user = await this.userService.GetById(id);
            user.City = await this.cityService.GetById(user.CityId);
            return View(user); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                this.userService.UpdateUser(user);
                await this.userService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id, int page) 
        {
            await this.userService.RemoveUser(id);
            await this.userService.SaveChanges();
            return RedirectToAction("Index", new { page = page });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                this.userService.CreateUser(userModel);
                await this.userService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        public IActionResult Search(int page, string search)
        {
            return RedirectToAction("Index", new {page=page, search = search});
        }
    }
}
