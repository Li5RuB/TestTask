using Microsoft.AspNetCore.Mvc;
using Task.Services.Services;

namespace Task.Web.Controllers
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
