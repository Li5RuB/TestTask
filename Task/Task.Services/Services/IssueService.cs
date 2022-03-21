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
        private readonly ITimeLogRepository _timeLogRepository;

        public IssueService(IIssueRepository issueRepository, ITimeLogRepository timeLogRepository)
        {
            _issueRepository = issueRepository;
            _timeLogRepository = timeLogRepository;
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

        public IssuePageModel GetIssuesToPage(int week,int mouth, int year, int userId)
        {
            if(week == 0)
                week = GetDefaultWeek();
            if (year == 0)
                year = GetDefaultYear();
            var dateForPage = new List<DateTime>();
            if(mouth != 0)
            {
                int allDay = DateTime.DaysInMonth(year, mouth);
                dateForPage = GetDateOfMouth(year, mouth, allDay);
            }else
            GetDaysOfWeek(week, year).ForEach(i => dateForPage.Add(i));
            var issueSearchResultModel = _issueRepository.GetIssueToPage(dateForPage, userId, week, year);
            var issueIds = issueSearchResultModel.IssueItems.Select(i => i.IssueId).ToList();
            issueSearchResultModel.TimeLogItems = _timeLogRepository.GetLogsToPage(dateForPage.First(), dateForPage.Last(), issueIds);
            var datePageModels = (from item in dateForPage
                                  select new DatePageModel()
                                  {
                                      Date = item.ToString("dd/MMM", CultureInfo.GetCultureInfo("en-US")),
                                      DayOfWeek = item.ToString("ddd", CultureInfo.GetCultureInfo("en-US")),
                                      FullDate = item,
                                  }).ToList();
            var issuePageModel = new IssuePageModel(
                issueSearchResultModel.IssueItems.Select(IssueMapper.MapItemToModel).ToList(),
                issueSearchResultModel.TimeLogItems.Select(TimeLogMapper.MapItemToModel).ToList(),
                datePageModels, 
                week,
                mouth,
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

        private static List<DateTime> GetDateOfMouth (int year, int mouth, int allDay)
        {
            var startDate = new DateTime(year, mouth, 1);
            var list = Enumerable.Range(0, allDay).Select(i => startDate.AddDays(i)).ToList();
            return list;
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

        private static int GetDefaultWeek()
        {
            var currentDay = DateTime.Now;
            var cal = new GregorianCalendar();
            var week = cal.GetWeekOfYear(currentDay, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            return week;
        }

        private static int GetDefaultYear()
        {
            return DateTime.Now.Year;
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
