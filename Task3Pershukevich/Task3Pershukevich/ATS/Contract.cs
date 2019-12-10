using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class Contract
    {
        public Client Client { get; private set; }
        public string NewNumber { get; private set; }
        public Tariff Tariff { get; private set; }

        public Contract() //client and tariff?
        {

        }

    }
}
