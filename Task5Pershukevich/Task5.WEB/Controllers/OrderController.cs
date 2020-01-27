using AutoMapper;
using Microsoft.Ajax.Utilities;
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
    [Authorize]
    public class OrderController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService(_connectionString);
        }

        public ActionResult Index(string manager, string client, string product)
        {
            var orderDtos = _orderService.GetOrdersByProperties(manager, client, product);

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ManagerDTO, ManagerViewModel>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<ClientDTO, ClientViewModel>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Lastname, opt => opt.MapFrom(src => src.Lastname));

                cfg.CreateMap<ProductDTO, ProductViewModel>()
                .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<OrderDTO, OrderViewModel>()
                .ForMember(o => o.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(o => o.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(o => o.Product, opt => opt.MapFrom(src => src.Product));
            }).CreateMapper();

            IEnumerable<OrderViewModel> orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);

            IList<ManagerViewModel> managers = orders.Select(o => o.Manager).DistinctBy(c => c.Lastname).ToList();
            managers.Insert(0, new ManagerViewModel { Lastname = "All", Id = 0 });

            IList<ClientViewModel> clients = orders.Select(o => o.Client).DistinctBy(c => c.Lastname).ToList();
            clients.Insert(0, new ClientViewModel { Lastname = "All", Id = 0 });

            IList<ProductViewModel> products = orders.Select(o => o.Product).DistinctBy(p => p.Name).ToList();
            products.Insert(0, new ProductViewModel { Name = "All", Id = 0 });

            OrderListViewModel orderList = new OrderListViewModel()
            {
                Orders = orders.ToList(),
                Managers = new SelectList(managers, "Lastname", "Lastname"),
                Clients = new SelectList(clients, "Lastname", "Lastname"),
                Products = new SelectList(products, "Name", "Name")
            };

            return View(orderList);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OrderDTO order = _orderService.GetOrderById(id);

            _orderService.DeleteOrder(order);

            return RedirectToAction("Index", "Order");
        }

        protected override void Dispose(bool disposing)
        {
            _orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}