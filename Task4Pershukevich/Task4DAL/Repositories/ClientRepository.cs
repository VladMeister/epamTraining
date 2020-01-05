using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.EF;
using Task4DAL.Entities;

namespace Task4DAL.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private SalesContext _salesContext { get; }

        public ClientRepository()
        {
            _salesContext = new SalesContext();
        }

        public void Add(Client client)
        {
            _salesContext.Clients.Add(client);
            _salesContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _salesContext.Clients.ToList();
        }

        public void Remove(Client client)
        {
            _salesContext.Clients.Remove(client);
            _salesContext.SaveChanges();
        }

        public Client GetById(int id)
        {
            return _salesContext.Clients.Find(id);
        }
    }
}
