using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCountries()
        {
            return Json(_countryService.GetAll());
        }
    }
}
