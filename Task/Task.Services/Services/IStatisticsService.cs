using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IStatisticsService
    {
        public CountStatisticsModel GetCountStatistics();

        public List<LastLoginStatisticsModel> GetLastLoginStatistics();
    }
}
