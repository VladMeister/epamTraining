using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4PL.Models
{
    public class OrderModel
    {
        public int Id { get; set; } //not needed?
        public double Cost { get; set; }
        public string Date { get; set; }

        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}
