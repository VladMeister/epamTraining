using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task4BL.Exceptions;
using Task4BL.DTO;
using Task4DAL.Repositories;

namespace Task4BL.Services
{
    public class SalesService : ISalesService
    {
        public GenericRepository<ClientDTO> ClientService { get; set; }
        public GenericRepository<ManagerDTO> ManagerService { get; set; }
        public GenericRepository<ProductDTO> ProductService { get; set; }
        public GenericRepository<OrderDTO> OrderService { get; set; }

        public SalesService()
        {
            ClientService = new GenericRepository<ClientDTO>();
            ManagerService = new GenericRepository<ManagerDTO>();
            ProductService = new GenericRepository<ProductDTO>();
            OrderService = new GenericRepository<OrderDTO>();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return OrderService.Get();
        }

        public OrderDTO GetOrderById(int id)
        {
            if (id < 0 || !OrderService.Get().Any(x => x.Id == id))
            {
                throw new InvalidIdException();
            }
            else
            {
                return OrderService.Get().FirstOrDefault(x => x.Id == id);
            }
        }

        public void AddOrder(OrderDTO order)
        {
            OrderService.Add(order);
        }

        public void RemoveOrder(OrderDTO order)
        {
            if(!OrderService.Get().Contains(order))
            {
                throw new ObjectNotExistingException();
            }
            else
            {
                OrderService.Remove(order);
            }
        }

        public void SaveOrdersChanges()
        {
            OrderService.Save();
        }

        public void Dispose()
        {
            ClientService.Dispose();
            ManagerService.Dispose();
            ProductService.Dispose();
            OrderService.Dispose();
        }
    }
}
