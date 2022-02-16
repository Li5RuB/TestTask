using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Models;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ITimeLogService _timeLogService;

        public IssueService(IIssueRepository issueRepository, ITimeLogService timeLogService)
        {
            _issueRepository = issueRepository;
            _timeLogService = timeLogService;
        }

        public async Task CreateIssue(IssueModel issue)
        {
            _issueRepository.Create(IssueMapper.MapModelToItem(issue));
            await _issueRepository.Save();
        }

        public async Task<IssueModel> GetById(int id)
        {
            return IssueMapper.MapItemToModel(await _issueRepository.GetById(id));
        }

        public List<IssueModel> GetIssuesByUserId(int id)
        {
            return _issueRepository.GetIssuesByUserId(id).Select(IssueMapper.MapItemToModel).ToList();
        }

        public IssuePageModel GetIssuesToPage(int week, int year, int userId)
        {
            week = CheckWeek(week);
            var dateForPage = new List<DateTime>();
            GetDaysOfWeek(week, year).ForEach(i => dateForPage.Add(i));
            var issueModels = _issueRepository.GetIssueToPage(dateForPage, userId, week, year);
            var issuePageModel = new IssuePageModel(
                issueModels.IssueItems.Select(IssueMapper.MapItemToModel).ToList(),
                issueModels.TimeLogItems.Select(TimeLogMapper.MapItemToModel).ToList(),
                dateForPage, 
                week, 
                year);
            return issuePageModel;
        }

        public async Task RemoveIssue(int id)
        {
            _issueRepository.Remove(await _issueRepository.GetById(id));
            await _issueRepository.Save();
        }

        public async Task UpdateIssue(IssueModel issue)
        {
            _issueRepository.Update(IssueMapper.MapModelToItem(issue));
            await _issueRepository.Save();
        }

        private static List<DateTime> GetDaysOfWeek(int numberOfWeek, int year)
        {
            var weekMonday = GetMonday(numberOfWeek, year);
            var startOfWeek = weekMonday.AddDays((int)GetDayOfWeek() - (int)weekMonday.DayOfWeek);
            var list = Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i)).ToList();
            return list;
        }

        private static DayOfWeek GetDayOfWeek()
        {
            var myCI = new CultureInfo("ru-RU");
            var myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myFirstDOW;
        }

        private static DateTime GetMonday(int numberWeek, int year)
        {
            var startDate = new DateTime(year, 1, 4);
            int offsetToFirstMonday = startDate.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)startDate.DayOfWeek - 1;
            int offsetToDemandedMonday = -offsetToFirstMonday + 7 * (numberWeek - 1);
            var mondayOfTheGivenWeek = startDate + new TimeSpan(offsetToDemandedMonday, 0, 0, 0);
            return mondayOfTheGivenWeek;
        }

        private static int CheckWeek(int week)
        {
            if (week == 0)
            {
                var currentDay = DateTime.Now;
                var cal = new GregorianCalendar();
                week = cal.GetWeekOfYear(currentDay, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            }
            return week;
        }

        public async Task CloseIssue(int id)
        {
            var issue = await _issueRepository.GetById(id);
            if (!issue.IsClosed)
            {
                issue.IsClosed = true;
                await _issueRepository.Save();
            }
        }
    }
}
