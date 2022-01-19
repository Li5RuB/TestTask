using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public JsonResult GetCitiesByCountryId(int id)
        {
            return Json(_cityService.GetCitiesByCountryId(id));
        }
    }
}
