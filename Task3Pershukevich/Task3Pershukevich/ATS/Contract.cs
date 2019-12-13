using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class Contract
    {
        public Client Client { get; }
        public string NewNumber { get; }
        public Tariff Tariff { get; }

        public Contract(Client client, Tariff tariff, string phoneNumber)
        {
            Client = client;
            Tariff = tariff;
            NewNumber = phoneNumber;
        }
    }
}
