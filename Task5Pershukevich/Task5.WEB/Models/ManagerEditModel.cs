using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WEB.Models
{
    public class ManagerEditModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }
    }
}