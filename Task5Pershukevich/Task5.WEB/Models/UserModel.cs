﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.BL.DTO;

namespace Task5.WEB.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}