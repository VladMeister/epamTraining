using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Manager()
        {
            Orders = new List<Order>();
        }
    }
}
