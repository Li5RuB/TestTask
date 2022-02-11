using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class TimeLogService : ITimeLogService
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public TimeLogService(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        public async Task CreateLog(TimeLogModel log)
        {
            _timeLogRepository.Create(TimeLogMapper.MapModelToItem(log));
            await _timeLogRepository.Save();
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
