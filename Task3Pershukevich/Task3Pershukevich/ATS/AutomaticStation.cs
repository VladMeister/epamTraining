using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class AutomaticStation
    {
        private IList<Client> _clientList;
        private IList<Contract> _contractList;

        private IDictionary<Port, Client> _portClientMapping;
        private IDictionary<Terminal, Client> _terminalClientMapping;

        public Contract CreateNewContract(Client client, Tariff tariff, string phoneNumber)
        {
            Contract contract = new Contract();

            return contract;
        }
    }
}
