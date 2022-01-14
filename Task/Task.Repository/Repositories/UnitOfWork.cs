using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;

namespace Task.Repository.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        private UserRepository userRepository;
        private CountryRepository countryRepository;
        private CityRepository cityRepository;
        private TitleRepository titleRepository;
        private bool disposed = false;

        public TitleRepository TitleRepository
        {
            get
            {
                if(titleRepository == null)
                {
                    this.titleRepository = new TitleRepository(context);
                }
                return titleRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return this.userRepository;
            }
        }

        public CountryRepository CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new CountryRepository(context);
                }
                return this.countryRepository;
            }
        }

        public CityRepository CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new CityRepository(context);
                }
                return this.cityRepository;
            }
        }

        public async System.Threading.Tasks.Task Save()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
