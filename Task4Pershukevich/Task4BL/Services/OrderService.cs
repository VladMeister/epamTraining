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
    public class OrderService : ISalesService<OrderDTO>
    {
        private OrderRepository orderRepository { get; }

        public OrderService(string connectionString)
        {
            orderRepository = new OrderRepository(connectionString);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orderRepository.GetAll());
        }

        public OrderDTO GetOrderById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                return mapper.Map<Order, OrderDTO>(orderRepository.GetById(id));
            }
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);

            orderRepository.Add(order);
        }

        public void Save()
        {
            orderRepository.Save();
        }

        public void Dispose()
        {
            orderRepository.Dispose();
        }
    }
}
