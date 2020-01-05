using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;
using Task4DAL.Entities;

namespace Task4DAL.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private SalesContext _salesContext { get; }

        public ManagerRepository()
        {
            _salesContext = new SalesContext();
        }

        public void Add(Manager manager)
        {
            _salesContext.Managers.Add(manager);
            _salesContext.SaveChanges();
        }

        public IEnumerable<Manager> GetAll()
        {
            return _salesContext.Managers.ToList();
        }

        public void Remove(Manager manager)
        {
            _salesContext.Managers.Remove(manager);
            _salesContext.SaveChanges();
        }

        public Manager GetById(int id)
        {
            return _salesContext.Managers.Find(id);
        }
    }
}
