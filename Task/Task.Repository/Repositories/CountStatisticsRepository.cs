using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class CountStatisticsRepository : BaseRepository<CountStatisticsItem>, IStatisticsRepository<CountStatisticsItem>
    {
        public CountStatisticsRepository(ApplicationDbContext context) : base(context)
        {
        }

    }

}
