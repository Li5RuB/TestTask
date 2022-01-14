using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Services.Models;

namespace Task.Services.Services
{
    public interface ITitleService
    {
        public Task<TitleModel> GetById(int id);

        public IEnumerable<TitleModel> GetAll();
    }
}
