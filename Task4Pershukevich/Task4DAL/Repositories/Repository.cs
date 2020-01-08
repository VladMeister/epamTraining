using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;

namespace Task4DAL.Repositories
{
    public class Repository
    {
        protected SalesContext salesContext { get; }

        public Repository(string connectionString)
        {
            salesContext = new SalesContext(connectionString);
        }

        public void Save()
        {
            salesContext.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    salesContext.Dispose();
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
