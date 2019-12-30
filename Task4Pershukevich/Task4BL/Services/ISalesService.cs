using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4BL.DTO;

namespace Task4BL.Services
{
    public interface ISalesService
    {
        void Dispose();
        IEnumerable<OrderDTO> GetOrders();
    }
}
