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
    public class ClientController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService(_connectionString);
        }

        [Authorize]
        public ActionResult Index(string searchString)
        {
            IEnumerable<ClientDTO> clientDtos = _clientService.GetClientsByLastname(searchString);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientViewModel>()).CreateMapper();
            var clients = mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(clientDtos);

            return View(clients);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string id, ClientEditModel clientModel)
        {
            IEnumerable<ClientDTO> clients = _clientService.GetClientsByLastname(id);

            if (ModelState.IsValid)
            {
                ClientDTO client = clients.FirstOrDefault(c => c.Lastname == id);

                _clientService.UpdateClient(client, clientModel.Firstname, clientModel.Lastname);

                return RedirectToAction("Index", "Client");
            }

            return View(clientModel);
        }

        public ActionResult Delete(string id)
        {
            IEnumerable<ClientDTO> clients = _clientService.GetClientsByLastname(id);
            ClientDTO client = clients.FirstOrDefault(c => c.Lastname == id);

            _clientService.DeleteClient(client);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _clientService.Dispose();
            base.Dispose(disposing);
        }
    }
}