using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;

namespace Task4DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IDisposable
    {
        public SalesContext SalesContext { get; }
        private DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            SalesContext = new SalesContext();
            _dbSet = SalesContext.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            SalesContext.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            SalesContext.SaveChanges();
        }

        public void Save()
        {
            SalesContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    SalesContext.Dispose();
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
