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
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await GetContext().FindAsync(id);
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

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public List<T> CallProcedure(string nameProcedure)
        {
            return _context.Set<T>().FromSqlRaw(nameProcedure).AsEnumerable().ToList();
        }

        protected virtual IQueryable<T> GetAll()
        {
            return GetContext();
        }

        private DbSet<T> GetContext()
        {
            return _context.Set<T>();
        }
    }
}
