using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;

namespace Task.Repository.Repositories
{
    public abstract class Repository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
