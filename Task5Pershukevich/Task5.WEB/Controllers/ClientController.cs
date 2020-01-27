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
    [Authorize]
    public class ClientController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService(_connectionString);
        }

        public ActionResult Index(string searchString)
        {
            IEnumerable<ClientDTO> clientDtos = _clientService.GetClientsByLastname(searchString);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientViewModel>()).CreateMapper();
            var clients = mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(clientDtos);

            return View(clients);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ClientDTO clientDTO = _clientService.GetClientById(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientEditModel>()).CreateMapper();
            ClientEditModel client  = mapper.Map<ClientDTO, ClientEditModel>(clientDTO);

            if (client != null)
            {
                return View(client);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ClientEditModel clientModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientEditModel, ClientDTO>()).CreateMapper();
                ClientDTO client = mapper.Map<ClientEditModel, ClientDTO>(clientModel);

                _clientService.UpdateClient(client);

                return RedirectToAction("Index", "Client");
            }

            return View(clientModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ClientDTO client = _clientService.GetClientById(id);

            _clientService.DeleteClient(client);

            return RedirectToAction("Index", "Client");
        }

        protected override void Dispose(bool disposing)
        {
            _clientService.Dispose();
            base.Dispose(disposing);
        }
    }
}