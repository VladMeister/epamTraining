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

        public void Update(Order order)
        {
            _salesContext.Entry(order).State = EntityState.Modified;
            _salesContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            Order orderToDelete = _salesContext.Orders.FirstOrDefault(o => o.Id == order.Id);

            if (orderToDelete != null)
            {
                _salesContext.Orders.Remove(orderToDelete);
            }
            _salesContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client).ToList();
        }

        public IEnumerable<Order> GetFilteredByProperties(string managerLastname, string clientLastname, string productName)
        {
            IEnumerable<Order> orders = _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client).ToList();

            if (!string.IsNullOrEmpty(managerLastname) && !managerLastname.Equals("All"))
            {
                orders = _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client)
                    .Where(o => o.Manager.Lastname == managerLastname).ToList();
            }
            if (!string.IsNullOrEmpty(clientLastname) && !clientLastname.Equals("All"))
            {
                orders = _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client)
                    .Where(o => o.Client.Lastname == clientLastname).ToList();
            }
            if (!string.IsNullOrEmpty(productName) && !productName.Equals("All"))
            {
                orders = _salesContext.Orders.Include(o => o.Manager).Include(o => o.Product).Include(o => o.Client)
                    .Where(o => o.Product.Name == productName).ToList();
            }

            return orders;
        }

        public Order GetById(int? id)
        {
            return _salesContext.Orders.Find(id);
        }
    }
}
