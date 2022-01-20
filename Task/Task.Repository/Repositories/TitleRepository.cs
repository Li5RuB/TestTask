using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class TitleRepository : BaseRepository<TitleItem>, ITitleRepository
    {
        public TitleRepository(ApplicationDbContext context) : base(context) { }

        public List<TitleItem> GetAllTitles()
        {
            return GetAll().ToList();
        }
    }
}
