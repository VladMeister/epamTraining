using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task5.BL.DTO;
using Task5.BL.Services;
using Task5.WEB.Models;

namespace Task5.WEB.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private UserService _userService;

        public HomeController()
        {
            _userService = new UserService(_connectionString);
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel logModel)
        {
            if (ModelState.IsValid)
            {
                bool userInDb = _userService.UserExists(logModel.Email, logModel.Password);

                if (userInDb)
                {
                    FormsAuthentication.SetAuthCookie(logModel.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with this login does not exist!");
                }
            }

            return View(logModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel regModel)
        {
            if (ModelState.IsValid)
            {
                UserModel user = null;

                bool userInDb = _userService.UserExists(regModel.Email, regModel.Password);

                if (!userInDb)
                {
                    user = new UserModel();

                    user.Email = regModel.Email;
                    user.Password = regModel.Password;

                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, UserDTO>()).CreateMapper();
                    UserDTO userDTO = mapper.Map<UserModel, UserDTO>(user);

                    _userService.RegisterUser(userDTO);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(regModel.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "There is already user with such login!");
                }
            }

            return View(regModel);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}