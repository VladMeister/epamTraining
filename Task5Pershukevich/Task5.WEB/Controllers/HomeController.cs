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
            //string result = "Your are not authorized";
            //if (User.Identity.IsAuthenticated)
            //{
            //    result = "Your login: " + User.Identity.Name;
            //}
            //return result;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                bool userInDb = _userService.LoginUser(email, password);

                if (userInDb)
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with this login does not exist!");
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string email, string password)
        {
            UserViewModel user = null;

            if (ModelState.IsValid)
            {
                bool userInDb = _userService.LoginUser(email, password);

                if (!userInDb)
                {
                    // создаем нового пользователя
                    user = new UserViewModel();

                    user.Email = email;
                    user.Password = password;

                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();
                    UserDTO userDTO = mapper.Map<UserViewModel, UserDTO>(user);

                    _userService.RegisterUser(userDTO);

                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "There is already user with such login!");
                }
            }

            return View(user);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}