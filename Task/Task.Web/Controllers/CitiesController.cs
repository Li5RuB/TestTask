using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public JsonResult GetCitiesByCountryId(int id)
        {
            return Json(this.cityService.GetCitiesByCountryId(id));
        }
    }
}
