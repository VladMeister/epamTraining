using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WEB.Models
{
    public class OrderViewModel //orderlistmodel
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}