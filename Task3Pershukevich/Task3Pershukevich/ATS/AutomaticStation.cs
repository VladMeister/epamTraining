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

        public Contract CreateNewContract(Client client, Tariff tariff, Port port, string phoneNumber, int terminalNumber)
        {
            Contract contract = new Contract(client, tariff);

            Port newPort = port;

            contract.SetNewNumber(phoneNumber);

            Terminal terminal = new Terminal(phoneNumber, terminalNumber);

            _clientList.Add(client);
            _portClientMapping.Add(newPort, client);
            _terminalClientMapping.Add(terminal, client);

            return contract;
        }

        public void AddContractToList(Contract contract)
        {
            _contractList.Add(contract);
        }

        public void SwitchPortState()
        {

        }
    }
}
