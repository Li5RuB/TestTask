using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public class CityRepository : Repository<CityItem>, ICityRepository
    {
        private readonly ApplicationDbContext context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<CityItem> GetUsers(Expression<Func<CityItem, bool>> expression)
        {
            return this.context.Cities.Where(expression);
        }
    }
}
