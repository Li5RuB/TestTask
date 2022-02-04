using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Models;
using TestTask.Services.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using TestTask.Services.Mappers;

namespace TestTask.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;

        public AccountController(IUserService userService, 
            IAuthorizationService authorizationService)
        {
            _userService = userService;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public IActionResult AccessDenied(string returnUrl)
        {
            return Redirect(returnUrl.Substring(0,returnUrl.LastIndexOf('/')));
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authorizationService.LoginUser(model);
                if (user !=null){
                    await Authenticate(await _authorizationService.GetClaimsIdentity(user));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password","invalid login or password");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user= await _userService.GetUserByEmail(model.Email);
                if (user == null)
                {
                    await _authorizationService.RegisterUser(model);
                    await Authenticate(await _authorizationService.GetClaimsIdentity(UserMapper.MapRegisterModelToModel(model)));
                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(ClaimsIdentity claimsIdentity)
        {
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}