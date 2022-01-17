using Microsoft.AspNetCore.Mvc;
using Task.Services.Services;

namespace Task.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public JsonResult GetCountries()
        {
            return Json(this.countryService.GetAll());
        }
    }
}
