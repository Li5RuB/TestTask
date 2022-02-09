using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface IStatisticsRepository<T> where T : class
    {
        public List<T> CallProcedure(string procedureName);
    }
}
