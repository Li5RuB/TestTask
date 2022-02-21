using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TestTask.Services.Models;
using TestTask.Services.Services;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly ITimeLogService _timeLogService;
        private readonly IUserService _userService;

        public IssuesController(
            IIssueService issueService, 
            ITimeLogService timeLogService, 
            IUserService userService)
        {
            _issueService = issueService;
            _timeLogService = timeLogService;
            _userService = userService;
        }

        public IActionResult Index(int week, int year)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = _issueService.GetIssuesToPage(week, year, userId);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new IssueModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(IssueModel model)
        {
            model.UserId = (await _userService.GetUserByEmail(model.UserEmail)).UserId;
            if (ModelState.IsValid)
            {
                await _issueService.CreateIssue(model);
                RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int issueId)
        {
            var issue = await _issueService.GetById(issueId);
            var timelogs = _timeLogService.GetLogsByIsueeId(issueId);
            return View(new IssueDetailsModel(issue, timelogs));
        }

        [HttpPost]
        public async Task<IActionResult> LogTime(TimeLogModel model)
        {
            if (ModelState.IsValid)
            {
                await _timeLogService.CreateLog(model);
            }
            return RedirectToAction("Details", new { issueId = model.IssueId });
        }

        public async Task<IActionResult> CloseIssue(int issueId)
        {
            await _issueService.CloseIssue(issueId);
            return RedirectToAction("Details", new { issueId = issueId });
        }
    }
}
