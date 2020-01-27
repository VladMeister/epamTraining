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
    public class UserRepository : Repository
    {
        private SalesContext _salesContext;

        public UserRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public void Register(User user)
        {
            _salesContext.Users.Add(user);
            _salesContext.SaveChanges();
        }

        public bool UserExists(string email, string password)
        {
            bool userExists = false;

            if(_salesContext.Users.Any(u => u.Email == email && u.Password == password))
            {
                userExists = true;
            }

            return userExists;
        }

        public IEnumerable<User> GetAll()
        {
            return _salesContext.Users.Include(u => u.Role).ToList();
        }
    }
}
