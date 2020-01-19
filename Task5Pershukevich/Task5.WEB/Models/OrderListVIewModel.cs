using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task5.WEB.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public SelectList Managers { get; set; }
        public SelectList Clients { get; set; }
        public SelectList Products { get; set; }
    }
}