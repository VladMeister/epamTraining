using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}