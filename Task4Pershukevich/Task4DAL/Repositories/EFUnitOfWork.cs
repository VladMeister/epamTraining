using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;
using Task4DAL.Entities;

namespace Task4DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SalesContext _salesContext { get; }

        public ClientRepository ClientRepository;
        public ManagerRepository ManagerRepository;
        public OrderRepository OrderRepository;
        public ProductRepository ProductRepository;

        public EFUnitOfWork()
        {
            _salesContext = new SalesContext();
            ClientRepository = new ClientRepository();
            ManagerRepository = new ManagerRepository();
            OrderRepository = new OrderRepository();
            ProductRepository = new ProductRepository();
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
