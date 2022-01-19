using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
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
