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
    public class ManagerController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private ManagerService _managerService;

        public ManagerController()
        {
            _managerService = new ManagerService(_connectionString);
        }

        [Authorize]
        public ActionResult Index(string searchString)
        {
            IEnumerable<ManagerDTO> managerDtos = _managerService.GetManagersByLastname(searchString);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, ManagerViewModel>()).CreateMapper();
            var managers = mapper.Map<IEnumerable<ManagerDTO>, List<ManagerViewModel>>(managerDtos);

            return View(managers);
        }

        protected override void Dispose(bool disposing)
        {
            _managerService.Dispose();
            base.Dispose(disposing);
        }
    }
}