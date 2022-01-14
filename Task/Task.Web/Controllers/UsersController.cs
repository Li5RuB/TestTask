using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Services.Models;
using Task.Services.Services;

namespace Task.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        
        public UsersController(IUserService userService, ITitleService titleService)
        {
            this.userService = userService;
        }

        public IActionResult Index(int page=1)
        {
            var pcount = this.userService.GetPageCount();
            if (pcount<page)
                page = 1;
            else if(page<1)
                page = pcount;
            var users = this.userService.GetByPage(page).ToList();
            ViewData["page"] = page;
            ViewData["pcount"] = pcount;
            return View(users);
        }

        public IActionResult Details()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id) 
        {
            return View(await this.userService.GetById(id)); 
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
    }
}
