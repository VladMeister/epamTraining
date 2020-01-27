using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.EF;
using Task5.DAL.Entities;

namespace Task5.DAL.Repositories
{
    public class RoleRepository : Repository
    {
        private SalesContext _salesContext;

        public RoleRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public void AddRole(Role role)
        {
            _salesContext.Roles.Add(role);
            _salesContext.SaveChanges();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _salesContext.Roles.ToList();
        }
    }
}
