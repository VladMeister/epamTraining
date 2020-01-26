using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.EF;
using Task5.DAL.Entities;

namespace Task5.DAL.Repositories
{
    public class ManagerRepository : Repository, IRepository<Manager>
    {
        private SalesContext _salesContext;

        public ManagerRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public int Add(Manager manager)
        {
            _salesContext.Managers.Add(manager);
            _salesContext.SaveChanges();

            return manager.Id;
        }

        public void Update(Manager manager)
        {
            _salesContext.Entry(manager).State = EntityState.Modified;
            _salesContext.SaveChanges();
        }

        public void Delete(Manager manager)
        {
            manager = _salesContext.Managers.Find(manager);
            if (manager != null)
            {
                _salesContext.Managers.Remove(manager);
            }
            _salesContext.SaveChanges();
        }

        public IEnumerable<Manager> GetAll()
        {
            return _salesContext.Managers.ToList();
        }

        public IEnumerable<Manager> GetFilteredByLastname(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return _salesContext.Managers.ToList();
            }
            return _salesContext.Managers.Where(m => m.Lastname == lastName).ToList();
        }

        public Manager GetById(int id)
        {
            return _salesContext.Managers.Find(id);
        }
    }
}
