﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
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
            var ordersList = _orderRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Manager, ManagerDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<Client, ClientDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<Product, ProductDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<Order, OrderDTO>()
                .ForMember(o => o.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(o => o.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(o => o.Product, opt => opt.MapFrom(src => src.Product));
            }).CreateMapper();

            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(ordersList);
        }

        public IEnumerable<OrderDTO> GetOrdersByProperties(string managerLastname, string clientLastname, string productName)
        {
            var ordersList = _orderRepository.GetFilteredByProperties(managerLastname, clientLastname, productName);

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Manager, ManagerDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<Client, ClientDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<Product, ProductDTO>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<Order, OrderDTO>()
                .ForMember(o => o.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(o => o.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(o => o.Product, opt => opt.MapFrom(src => src.Product));
            }).CreateMapper();

            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(ordersList);
        }

        public OrderDTO GetOrderById(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<Order, OrderDTO>(_orderRepository.GetById(id));
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
