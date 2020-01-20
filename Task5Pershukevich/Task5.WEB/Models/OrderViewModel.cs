using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public ManagerViewModel Manager { get; set; }

        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }
    }
}