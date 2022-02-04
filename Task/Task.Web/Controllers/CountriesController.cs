using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Services.Models;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index(int page = 1, string search = null)
        {
            var countryPageModel = _countryService.GetCountryPageModel(page, search);
            ViewData["page"] = countryPageModel.CurrentPage;
            ViewData["pcount"] = countryPageModel.PageCount;
            ViewData["search"] = search;
            return View(countryPageModel.CountryModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                await _countryService.CreateCountry(countryModel);
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryService.GetById(id);
            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                await _countryService.UpdateCountry(countryModel);
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _countryService.RemoveCountry(id);
            return RedirectToAction("Index");
        }

        public IActionResult Search(int page, string search)
        {
            return RedirectToAction("Index", new { page = page, search = search });
        }

        [HttpGet]
        public JsonResult GetCountries()
        {
            return Json(_countryService.GetAll());
        }
    }
}
