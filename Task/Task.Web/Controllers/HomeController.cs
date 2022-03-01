using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TestTask.Services.Models;
using TestTask.Services.Services;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IIssueService _issueService;

        public HomeController(IStatisticsService statisticsService, IIssueService issueService)
        {
            _statisticsService = statisticsService;
            _issueService = issueService;
        }

        public IActionResult Index()
        {
            var countStatistictsModel = _statisticsService.GetCountStatistics();
            var lastloginStatisticsModels = _statisticsService.GetLastLoginStatistics();
            return View(new StatisticsModel(countStatistictsModel, lastloginStatisticsModels));
        }
    }
}
