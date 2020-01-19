using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.BL.DTO;
using Task5.BL.Services;
using Task5.WEB.Models;

namespace Task5.WEB.Controllers
{
    public class OrderController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService(_connectionString);
        }

        public ActionResult Index(int? manager, int? client, int? product)
        {
            IEnumerable<OrderDTO> orderDtos = _orderService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);

            OrderListViewModel orderList = new OrderListViewModel();

            return View(orderList);
        }

        protected override void Dispose(bool disposing)
        {
            _orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}