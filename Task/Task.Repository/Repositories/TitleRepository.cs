using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public class TitleRepository : Repository<TitleItem>, ITitleRepository
    {
        public TitleRepository(ApplicationDbContext context) : base(context) { }
    }
}
