using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleModel> GetById(int id)
        {
            return RoleMapper.MapItemToModel(await _roleRepository.GetById(id));
        }

        public List<RoleModel> GetAll()
        {
            return _roleRepository.GetAllRoles().Select(RoleMapper.MapItemToModel).ToList();
        }
    }
}