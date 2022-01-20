using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public JsonResult GetTitles()
        {
            return Json(_titleService.GetAll());
        }
    }
}
