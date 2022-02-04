using System.Collections.Generic;
using System.Linq;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class RoleRepository : BaseRepository<RoleItem>, IRoleRepository

    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<RoleItem> GetAllRoles()
        {
            return GetAll().ToList();
        }
    }
}