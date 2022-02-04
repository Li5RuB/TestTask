using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class RoleMapper
    {
        public static RoleModel MapItemToModel(RoleItem item)
        {
            return new RoleModel()
            {
                RoleId = item.RoleId,
                Name = item.Name
            };
        }

        public static RoleItem MapModelToItem(RoleModel model)
        {
            return new RoleItem()
            {
                RoleId = model.RoleId,
                Name = model.Name
            };
        }
    }
}