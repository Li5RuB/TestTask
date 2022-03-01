using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface ITimeLogService
    {
        public Task<TimeLogModel> GetById(int id);

        public List<TimeLogModel> GetLogsByIsueeId(int id);

        public List<TimeLogModel> GetLogsToPage(DateTime date);

        public Task CreateLog(TimeLogModel log);

        public Task RemoveLog(int id);

        public Task UpdateLog(TimeLogModel log);
    }
}
