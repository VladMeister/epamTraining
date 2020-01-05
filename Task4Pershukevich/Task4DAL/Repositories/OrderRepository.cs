using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task4DAL.Entities;
using Task4DAL.EF;

namespace Task4DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private SalesContext _salesContext { get; }

        public OrderRepository()
        {
            _salesContext = new SalesContext();
        }

        public void Add(Order order)
        {
            _salesContext.Orders.Add(order);
            _salesContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _salesContext.Orders.Include(o => o.Client).Include(o => o.Manager).Include(o => o.Product).ToList();
        }

        public void Remove(Order order)
        {
            _salesContext.Orders.Remove(order);
            _salesContext.SaveChanges();
        }

        public Order GetById(int id)
        {
            return _salesContext.Orders.Find(id);
        }
    }
}
