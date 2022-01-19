using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;

namespace TestTask.Repository.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await GetContext().FindAsync(id);
        }

        protected virtual IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual void Create(T item)
        {
            GetContext().Add(item);
        }

        public virtual void Remove(T item)
        {
            GetContext().Remove(item);
        }

        public virtual void Update(T item)
        {
            GetContext().Update(item);
        }

        public virtual async System.Threading.Tasks.Task Save()
        {
            await context.SaveChangesAsync();
        }

        private DbSet<T> GetContext()
        {
            return context.Set<T>();
        }
    }
}
