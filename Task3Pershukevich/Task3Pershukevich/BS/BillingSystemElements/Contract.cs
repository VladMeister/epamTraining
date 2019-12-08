using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BS.BillingSystemElements
{
    public class Contract
    {
        public Client client { get; private set; }
        public int NewNumber { get; private set; }
        public TariffType tariff { get; private set; }

        public Contract() //client and tariff?
        {

        }

    }
}
