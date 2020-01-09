using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save();
    }
}
