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
    public class AccountController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private UserService _userService;

        public AccountController()
        {
            _userService = new UserService(_connectionString);
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
                    ModelState.AddModelError("", "Check your login or password!");
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
                    int userRoleId;

                    user.Email = regModel.Email;
                    user.Password = regModel.Password;
                    userRoleId = _userService.GetUserRoles().FirstOrDefault(r => r.Name == "user").Id;

                    UserDTO userDTO = new UserDTO() { Email = user.Email, Password = user.Password, RoleId = userRoleId }; 

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
            return RedirectToAction("Login", "Account");
        }

        private bool CheckForExistingUserRole(UserService userService, string roleName)
        {
            return userService.GetUserRoles().Any(r => r.Name == roleName);
        }
    }
}