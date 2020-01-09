using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.EF;
using Task4.DAL.Entities;

namespace Task4.DAL.Repositories
{
    public class ManagerRepository : Repository, IRepository<Manager>
    {
        private SalesContext _salesContext { get; }

        public ManagerRepository(string connectionString) : base(connectionString)
        {
            _salesContext = salesContext;
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

        public Manager GetById(int id)
        {
            return _salesContext.Managers.Find(id);
        }
    }
}
