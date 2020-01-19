using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
using Task5.BL.Exceptions;
using Task5.DAL.Entities;
using Task5.DAL.Repositories;

namespace Task5.BL.Services
{
    public class OrderService : ISalesService<OrderDTO>
    {
        private OrderRepository _orderRepository;

        public OrderService(string connectionString)
        {
            _orderRepository = new OrderRepository(connectionString);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(_orderRepository.GetAll());
        }

        public OrderDTO GetOrderById(int id)
        {
            if (id < 0)
            {
                return null;
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                return mapper.Map<Order, OrderDTO>(_orderRepository.GetById(id));
            }
        }

        public int AddOrder(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);

            var orderId = _orderRepository.Add(order);

            return orderId;
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);

            _orderRepository.Update(order);
        }

        public void DeleteOrder(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            Order order = mapper.Map<OrderDTO, Order>(orderDTO);

            _orderRepository.Delete(order);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
