using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface ITitleRepository
    {
        public Task<TitleItem> GetById(int id);

        public List<TitleItem> GetAllTitles();
    }
}
