using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICityService _cityService;
        
        public UsersController(IUserService userService, ICityService cityService)
        {
            _userService = userService;
            _cityService = cityService;
        }
        
        public async Task<IActionResult> Index(UserPageModel model)
        {
            var userPageModel = await _userService.GetUserPageModel(model);
            return View(userPageModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id) 
        {
            var user = await _userService.GetById(id);
            user.City = await _cityService.GetById(user.CityId);
            return View(user); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, int page) 
        {
            await _userService.RemoveUser(id);
            return RedirectToAction("Index", new { page = page });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(userModel);
                return RedirectToAction("Index");
            }
            return View(userModel);
        }
    }
}
