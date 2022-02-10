using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class TimeLogRepository : BaseRepository<TimeLogItem>, ITimeLogRepository
    {
        public TimeLogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
