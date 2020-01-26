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
    public class ClientRepository : Repository, IRepository<Client>
    {
        private SalesContext _salesContext;

        public ClientRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public int Add(Client client)
        {
            _salesContext.Clients.Add(client);
            _salesContext.SaveChanges();

            return client.Id;
        }

        public void Update(Client client)
        {
            _salesContext.Entry(client).State = EntityState.Modified;
            _salesContext.SaveChanges();
        }

        public void Delete(Client client)
        {
            client = _salesContext.Clients.Find(client);
            if (client != null)
            {
                _salesContext.Clients.Remove(client);
            }
            _salesContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _salesContext.Clients.ToList();
        }

        public IEnumerable<Client> GetFilteredByLastname(string lastName)
        {
            if(string.IsNullOrEmpty(lastName))
            {
                return _salesContext.Clients.ToList();
            }
            return _salesContext.Clients.Where(c => c.Lastname == lastName).ToList();
        }

        public Client GetById(int id)
        {
            return _salesContext.Clients.Find(id);
        }
    }
}
