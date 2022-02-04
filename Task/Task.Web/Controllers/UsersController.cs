using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICountryService _countryService;
        private readonly ITitleService _titleService;
        private readonly ICityService _cityService;
        
        public UsersController(IUserService userService, ITitleService titleService, ICountryService countryService, ICityService cityService)
        {
            _userService = userService;
            _countryService = countryService;
            _cityService = cityService;
            _titleService = titleService;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var userPageModel = _userService.GetUserPageModel(page, search);
            ViewData["page"] = userPageModel.CurrentPage;
            ViewData["pcount"] = userPageModel.PageCount;
            ViewData["search"] = search;
            return View(await _userService.GetAllUserFields(userPageModel.UserModels));
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var user = await _userService.GetById(id);
            user.City = await _cityService.GetById(user.CityId);
            return View(user); 
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id, int page) 
        {
            await _userService.RemoveUser(id);
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
                await _userService.CreateUser(userModel);
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
