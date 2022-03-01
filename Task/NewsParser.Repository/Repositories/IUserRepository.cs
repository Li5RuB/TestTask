using NewsParser.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Repositories.Repositories
{
    public interface IUserRepository
    {
        public List<UserItem> GetUsers();
    }
}
