using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public interface ITitleRepository
    {
        public Task<TitleItem> GetById(int id);

        public IEnumerable<TitleItem> GetAll();
    }
}
