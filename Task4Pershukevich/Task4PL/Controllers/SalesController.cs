using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Task4BL.DTO;
using Task4BL.Services;
using Task4PL.Models;
using Task4BL.Exceptions;


namespace Task4PL.Controllers
{
    public class SalesController
    {
        private SalesService salesService { get; }

        public SalesController()
        {
            salesService = new SalesService();
        }

        public IEnumerable<OrderModel> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderModel>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderDTO>, List<OrderModel>>(salesService.GetOrders());
        }

        public OrderModel GetOrderById(int id)
        {
            try
            {
                OrderDTO orderDTO = salesService.GetOrderById(id);
                var order = new OrderModel { Cost = orderDTO.Cost, Date = orderDTO.Date }; //id?

                return order;
            }

            catch (InvalidIdException ex)
            {
                throw ex;//?
            }
        }

        public void AddOrder(OrderModel order)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                Cost = order.Cost,
                Date = order.Date,
                ClientId = order.ClientId,
                ManagerId = order.ManagerId,
                ProductId = order.ProductId
            };

            salesService.AddOrder(orderDTO);
        }

        public void RemoveOrder(OrderModel order)
        {
            try
            {
                OrderDTO orderDTO = salesService.GetOrders().FirstOrDefault(o => o.Cost == order.Cost
                && o.Date == order.Date && o.ProductId == order.ProductId && o.ManagerId == order.ManagerId
                && o.ClientId == order.ClientId);

                salesService.RemoveOrder(orderDTO); //saving on dal
            }

            catch(ObjectNotExistingException ex)
            {
                throw ex;
            }
        }

        public void SaveChanges()
        {
            salesService.SaveOrdersChanges();
        }

        public void Dispose()
        {
            salesService.Dispose();
        }
    }
}
