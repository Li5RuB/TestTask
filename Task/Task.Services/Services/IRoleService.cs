using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IRoleService
    {
        public Task<RoleModel> GetById(int id);

        public List<RoleModel> GetAll();
    }
}