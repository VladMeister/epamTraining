using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.Entities;

namespace Task4DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
