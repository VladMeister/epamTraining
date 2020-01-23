using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }

        public int ManagerId { get; set; }
        public ManagerDTO Manager { get; set; }

        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
