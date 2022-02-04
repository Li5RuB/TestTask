using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface IRoleRepository
    {
        public Task<RoleItem> GetById(int id);

        public List<RoleItem> GetAllRoles();
    }
}