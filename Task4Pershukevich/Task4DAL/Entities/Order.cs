using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public string Date { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
