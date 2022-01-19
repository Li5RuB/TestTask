using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
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
            var userPageModel = userService.GetUserPageModel(page, search);
            ViewData["page"] = userPageModel.currentPage;
            ViewData["pcount"] = userPageModel.pageCount;
            ViewData["search"] = search;
            return View(await userService.GetAllUserFields(userPageModel.UserModels));
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
            return View();
        }

        public IActionResult Search(int page, string search)
        {
            return RedirectToAction("Index", new {page=page, search = search});
        }
    }
}
