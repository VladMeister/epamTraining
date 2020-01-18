using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task5.DAL.EF;
using Task5.DAL.Entities;

namespace Task5.DAL.Repositories
{
    public class OrderRepository : Repository, IRepository<Order>
    {
        //add two more rpositories: user and userRoles

        private SalesContext _salesContext;

        public OrderRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public int Add(Order order)
        {
            _salesContext.Orders.Add(order);
            _salesContext.SaveChanges();

            return order.Id;
        }

        public IEnumerable<Order> GetAll()
        {
            return _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client).ToList();
        }

        public Order GetById(int id) //replace with find(delegate)
        {
            return _salesContext.Orders.Find(id);
        }
    }
}
