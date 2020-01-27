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
    public class ManagerController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private ManagerService _managerService;

        public ManagerController()
        {
            _managerService = new ManagerService(_connectionString);
        }

        public ActionResult Index(string searchString)
        {
            IEnumerable<ManagerDTO> managerDtos = _managerService.GetManagersByLastname(searchString);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, ManagerViewModel>()).CreateMapper();
            var managers = mapper.Map<IEnumerable<ManagerDTO>, List<ManagerViewModel>>(managerDtos);

            return View(managers);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ManagerDTO managerDTO = _managerService.GetManagerById(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, ManagerEditModel>()).CreateMapper();
            ManagerEditModel manager = mapper.Map<ManagerDTO, ManagerEditModel>(managerDTO);

            if (manager != null)
            {
                return View(manager);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ManagerEditModel managerModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerEditModel, ManagerDTO>()).CreateMapper();
                ManagerDTO manager = mapper.Map<ManagerEditModel, ManagerDTO>(managerModel);

                _managerService.UpdateManager(manager);

                return RedirectToAction("Index", "Manager");
            }

            return View(managerModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ManagerDTO manager = _managerService.GetManagerById(id);

            _managerService.DeleteManager(manager);

            return RedirectToAction("Index", "Manager");
        }

        protected override void Dispose(bool disposing)
        {
            _managerService.Dispose();
            base.Dispose(disposing);
        }
    }
}