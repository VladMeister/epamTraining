using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using Task5.BL.Services;

namespace Task5.WEB.Providers
{
    //<roleManager enabled = "true" defaultProvider="MyRoleProvider">
    //  <providers>
    //    <add name = "MyRoleProvider" type="Task5.WEB.Providers.CustomRoleProvider" />
    //  </providers>
    //</roleManager> after auth in web config

//    public class CustomRoleProvider : RoleProvider
//    {
//        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

//        private UserService _userService;

//        public override string[] GetRolesForUser(string username)
//        {
//            string[] roles = new string[] { };
//             (UserService userService = new UserService(_connectionString)
            
//                // Получаем пользователя
//                User user = userService.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == username);
//                if (user != null && user.Role != null)
//                {
//                    // получаем роль
//                    roles = new string[] { user.Role.Name };
//                }
//                return roles;
//            }
//        }
//        public override void CreateRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }
//        public override bool IsUserInRole(string username, string roleName)
//        {
//            using (SalesContext db = new SalesContext())
//            {
//                // Получаем пользователя
//                User user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == username);

//                if (user != null && user.Role != null && user.Role.Name == roleName)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override string ApplicationName
//        {
//            get { throw new NotImplementedException(); }
//            set { throw new NotImplementedException(); }
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetAllRoles()
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetUsersInRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new NotImplementedException();
//        }
//    }
}