using Microsoft.AspNetCore.Mvc;
using Task.Services.Services;

namespace Task.Web.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleService titleService;

        public TitlesController(ITitleService titleService)
        {
            this.titleService = titleService;
        }

        [HttpGet]
        public JsonResult GetTitles()
        {
            return Json(this.titleService.GetAll());
        }
    }
}
