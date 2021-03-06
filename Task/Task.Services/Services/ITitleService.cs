using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface ITitleService
    {
        public Task<TitleModel> GetById(int id);

        public List<TitleModel> GetAll();
    }
}
