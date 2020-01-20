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

        public ActionResult Index(string manager, string client, string product)
        {
            IEnumerable<OrderDTO> orderDtos = _orderService.GetAll();
            if (orderDtos.Any())
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
                IEnumerable<OrderViewModel> orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);

                if (!string.IsNullOrEmpty(manager) && !manager.Equals("All"))
                {
                    orders = orders.Where(o => o.Manager.Lastname == manager);
                }
                if (!string.IsNullOrEmpty(client) && !client.Equals("All"))
                {
                    orders = orders.Where(o => o.Client.Lastname == client);
                }
                if (!string.IsNullOrEmpty(product) && !product.Equals("All"))
                {
                    orders = orders.Where(o => o.Product.Name == product);
                }

                //IList<ManagerViewModel> managers = orders.Select(o => o.Manager).ToList();
                //managers.Insert(0, new ManagerViewModel { Lastname  = "All", Id = 0 });

                //IList<ClientViewModel> clients = orders.Select(o => o.Client).ToList();
                //clients.Insert(0, new ClientViewModel {  Lastname = "All", Id = 0 });

                //IList<ProductViewModel> products = orders.Select(o => o.Product).ToList();
                //products.Insert(0, new ProductViewModel { Name = "All", Id = 0 });

                OrderListViewModel orderList = new OrderListViewModel();
                //{
                //    Orders = orders.ToList(),
                //    Managers = new SelectList(managers, "Id", "Name"),
                //    Clients = new SelectList(clients, "Id", "Name"),
                //    Products = new SelectList(products, "Id", "Name")
                //};

                return View(orderList);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}