using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Services;

namespace TestTask.Web.Controllers
{
    [Authorize]
    public class TitlesController : Controller
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTitles()
        {
            return Json(_titleService.GetAll());
        }
    }
}
