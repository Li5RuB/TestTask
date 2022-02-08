using System.Collections.Generic;
using TestTask.Services.Models;

namespace TestTask.Web.Models
{
    public class StatisticsModel
    {
        public StatisticsModel(CountStatisticsModel countStatistics, List<LastLoginStatisticsModel> lastLoginStatistics)
        {
            CountStatistics = countStatistics;
            LastLoginStatistics = lastLoginStatistics;
        }

        public CountStatisticsModel CountStatistics { get; set; }

        public List<LastLoginStatisticsModel> LastLoginStatistics { get; set; }
    }
}
