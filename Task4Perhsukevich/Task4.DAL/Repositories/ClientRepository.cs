using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.EF;
using Task4.DAL.Entities;

namespace Task4.DAL.Repositories
{
    public class ClientRepository : Repository, IRepository<Client>
    {
        private SalesContext _salesContext { get; }

        public ClientRepository(string connectionString) : base(connectionString)
        {
            _salesContext = salesContext;
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

        public Client GetById(int id)
        {
            return _salesContext.Clients.Find(id);
        }
    }
}
