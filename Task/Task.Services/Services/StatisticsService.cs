using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository<CountStatisticsItem> _countStatisticsRepository;
        private readonly IStatisticsRepository<LastLoginStatisticsItem> _lastLoginStatisticsRepository;
        
        public StatisticsService(IStatisticsRepository<CountStatisticsItem> countStatisticsRepository, IStatisticsRepository<LastLoginStatisticsItem> lastLoginStatisticsRepository)
        {
            _countStatisticsRepository = countStatisticsRepository;
            _lastLoginStatisticsRepository = lastLoginStatisticsRepository;
        }

        public CountStatisticsModel GetCountStatistics()
        {
            return CountStatisticsMapper.MapItemToModel(_countStatisticsRepository.CallProcedure("EXEC CountStatistics").FirstOrDefault());
        }

        public List<LastLoginStatisticsModel> GetLastLoginStatistics()
        {
            var lastLoginStatisticsItem = _lastLoginStatisticsRepository.CallProcedure("EXEC LastLoginStatistics");
            var lastLoginStatisticsModel = new List<LastLoginStatisticsModel>();
            foreach (var item in lastLoginStatisticsItem)
            {
                lastLoginStatisticsModel.Add(LastLoginStatisticsMapper.MapItemToModel(item));
            }
            return lastLoginStatisticsModel;
        }
    }
}
