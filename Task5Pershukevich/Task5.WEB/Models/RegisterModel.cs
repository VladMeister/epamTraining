﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WEB.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Password length must be 8 characters.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not equal!")]
        public string ConfirmPassword { get; set; }
    }
}