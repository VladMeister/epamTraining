using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task5.BL.DTO;
using Task5.BL.Services;

namespace Task5.WEB.Models
{
    //public class RoleDbInitializer : DropCreateDatabaseIfModelChanges<UserService>
    //{
    //    protected override void Seed(UserService userService)
    //    {
    //        RoleDTO admin = new RoleDTO { Name = "admin" };
    //        RoleDTO user = new RoleDTO { Name = "user" };
    //        userService.AddUserRole(admin);
    //        userService.AddUserRole(user);
    //        userService.RegisterUser(new UserDTO
    //        {
    //            Email = "mr.vlad0207@mail.com",
    //            Password = "12345678",
    //            Role = admin
    //        });
    //        base.Seed(userService);
    //    }
    //}
}