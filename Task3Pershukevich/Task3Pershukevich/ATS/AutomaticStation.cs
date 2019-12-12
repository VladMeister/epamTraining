using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.EventCallArgs;

namespace Task3Pershukevich.ATS
{
    public class AutomaticStation : IATS
    { 
        private IList<Client> _clientList;
        private IList<Contract> _contractList;

        private IDictionary<Port, Client> _portClientMapping;
        private IDictionary<Terminal, Client> _terminalClientMapping;

        public Contract CreateNewContract(Client client, Tariff tariff, Port port, string phoneNumber, int terminalNumber)
        {
            Contract contract = new Contract(client, tariff);

            Port newPort = port;

            //newPort.ChangePortCondition += SwitchPortState;

            contract.SetNewNumber(phoneNumber);

            Terminal terminal = new Terminal(phoneNumber, terminalNumber);

            //terminal.MakeACallEvent += MakingACall;
            //terminal.AnswerACallEvent += Calling;
            //terminal.EndACallEvent += Calling;

            _clientList.Add(client);
            _portClientMapping.Add(newPort, client);
            _terminalClientMapping.Add(terminal, client);
            _contractList.Add(contract);

            return contract;
        }

        public void MakingACall(object sender, MakeACall makeACall)
        {

        }

        public void SwitchPortState(PortCondition portCondition)
        {

        }

        public bool CheckAvailabilityOfNumber(string callingNumber, int portId)
        {
            bool numberIsFree = false;

            if (ExistNumber(callingNumber))
            {
                numberIsFree = _portClientMapping.Where(x => x.Key.PortCondition == PortCondition.Free).Any(p => p.Key.IdNumber == portId);
            }

            return numberIsFree;
        }

        public bool ExistNumber(string callingNumber)
        {
            bool numberExists = false;

            if (_terminalClientMapping.Any(x => x.Key.PhoneNumber == callingNumber))
            {
                numberExists = true;
            }

            return numberExists;
        }
    }
}
