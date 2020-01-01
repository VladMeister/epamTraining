using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;

namespace Task4DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private SalesContext _salesContext { get; }
        private DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            _salesContext = new SalesContext();
            _dbSet = _salesContext.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _salesContext.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _salesContext.SaveChanges();
        }

        public void Save()
        {
            _salesContext.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _salesContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
