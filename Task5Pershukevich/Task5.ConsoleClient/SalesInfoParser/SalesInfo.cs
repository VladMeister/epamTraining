using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.ConsoleClient.SalesInfoParser
{
    public class SalesInfo
    {
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Cost { get; set; }
    }
}
