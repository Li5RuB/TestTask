using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var cityPageModel = _cityService.GetCityPageModel(page, search);
            ViewData["page"] = cityPageModel.CurrentPage;
            ViewData["pcount"] = cityPageModel.PageCount;
            ViewData["search"] = search;
            return View(await _cityService.GetCountryForCities(cityPageModel.CityModels));
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                await _cityService.CreateCity(cityModel);
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityService.GetById(id);
            return View(city);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                await _cityService.UpdateCity(cityModel);
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }
        
        public async Task<IActionResult> Delete(int id, int page)
        {
            await _cityService.RemoveCity(id);
            return RedirectToAction("Index", new { page = page });
        }
        
        public IActionResult Search(int page, string search)
        {
            return RedirectToAction("Index", new { page = page, search = search });
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCitiesByCountryId(int id)
        {
            return Json(_cityService.GetCitiesByCountryId(id));
        }
    }
}
