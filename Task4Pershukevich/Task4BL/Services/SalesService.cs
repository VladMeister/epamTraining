using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Task4BL.Exceptions;
using Task4BL.DTO;
using Task4DAL.Repositories;
using Task4DAL.Entities;
using AutoMapper;

namespace Task4BL.Services
{
    public class SalesService : ISalesService
    {
        private EFUnitOfWork dataBase { get; }

        public SalesService()
        {
            dataBase = new EFUnitOfWork();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(dataBase.OrderRepository.GetAll());
        }

        public OrderDTO GetOrderById(int id)
        {
            if (id < 0 || !dataBase.OrderRepository.GetAll().Any(x => x.Id == id))
            {
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var order = dataBase.OrderRepository.GetById(id);

                return new OrderDTO { Date = order.Date, Cost = order.Cost };
            }
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            Order order = new Order
            {
                Cost = orderDTO.Cost,
                Date = orderDTO.Date,
                ClientId = orderDTO.ClientId,
                ManagerId = orderDTO.ManagerId,
                ProductId = orderDTO.ProductId
            };

            dataBase.OrderRepository.Add(order);
        }

        public void RemoveOrder(OrderDTO orderDTO)
        {
            Order order = dataBase.OrderRepository.GetAll().FirstOrDefault(o => o.Cost == orderDTO.Cost
            && o.Date == orderDTO.Date && o.ProductId == orderDTO.ProductId && o.ManagerId == orderDTO.ManagerId
            && o.ClientId == orderDTO.ClientId);

            if(!dataBase.OrderRepository.GetAll().Contains(order))
            {
                throw new ObjectNotExistingException("This order does not exist!");
            }
            else
            {
                dataBase.OrderRepository.Remove(order);
            }
        }

        public void SaveOrdersChanges()
        {
            dataBase.Save();
        }

        public void Dispose()
        {
            dataBase.Dispose();
        }
    }
}
