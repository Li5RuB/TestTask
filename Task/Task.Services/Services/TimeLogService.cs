using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class TimeLogService : ITimeLogService
    {
        private readonly ITimeLogRepository _timeLogRepository;
        private readonly IIssueRepository _issueRepository;
        private readonly long tenHours = new TimeSpan(10, 0, 0).Ticks;

        public TimeLogService(ITimeLogRepository timeLogRepository, IIssueRepository issueRepository)
        {
            _timeLogRepository = timeLogRepository;
            _issueRepository = issueRepository;
        }

        public async Task CreateLog(TimeLogModel log)
        {
            var loggedTime = _timeLogRepository.GetLogsByDate(log.DateLog).Sum(x=>x.Time.Ticks);
            var issueStatus = (await _issueRepository.GetById(log.IssueId)).IsClosed;
            if ((loggedTime+log.Time.Ticks)<= tenHours)
            {
                _timeLogRepository.Create(TimeLogMapper.MapModelToItem(log));
                await _timeLogRepository.Save();
            }
        }

        public async Task<TimeLogModel> GetById(int id)
        {
            return TimeLogMapper.MapItemToModel(await _timeLogRepository.GetById(id));
        }

        public List<TimeLogModel> GetLogsByIsueeId(int id)
        {
            return _timeLogRepository.GetLogsByIsueeId(id).Select(TimeLogMapper.MapItemToModel).ToList();
        }

        public List<TimeLogModel> GetLogsToPage(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRangeByDate(int issueId, DateTime date)
        {
            var logsIds = _timeLogRepository.GetLogsByDate(date).Where(i=>i.IssueId==issueId).ToList();
            await _timeLogRepository.RemoveRange(logsIds);
            await _timeLogRepository.Save();
        }

        public async Task RemoveLog(int id)
        {
            _timeLogRepository.Remove(await _timeLogRepository.GetById(id));
            await _timeLogRepository.Save();
        }

        public async Task UpdateLog(TimeLogModel log)
        {
            _timeLogRepository.Update(TimeLogMapper.MapModelToItem(log));
            await _timeLogRepository.Save();
        }
    }
}
