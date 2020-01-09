using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}
