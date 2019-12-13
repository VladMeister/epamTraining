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

        public AutomaticStation()
        {
            _clientList = new List<Client>();
            _contractList = new List<Contract>();
            _portClientMapping = new Dictionary<Port, Client>();
            _terminalClientMapping = new Dictionary<Terminal, Client>();
        }

        public Contract CreateNewContract(Client client, Tariff tariff, Port port, string phoneNumber, int terminalNumber)
        {
            Contract contract = new Contract(client, tariff);

            var newPort = port;

            newPort.ChangePortCondition += SwitchPortState;

            contract.SetNewNumber(phoneNumber);

            Terminal terminal = new Terminal(phoneNumber, terminalNumber);

            terminal.MakeACallEvent += MakingACall;
            terminal.AnswerACallEvent += AnsweringACall;
            terminal.EndACallEvent += EndingACall;

            _clientList.Add(client);
            _portClientMapping.Add(newPort, client);
            _terminalClientMapping.Add(terminal, client);
            _contractList.Add(contract);

            return contract;
        }

        public void MakingACall(object sender, MakeACall args)
        {
            if(CheckAvailabilityOfNumber(args.DestintionNumber, args.destinationPortID) && CheckSelfNumber(args.PhoneNumber, args.DestintionNumber))
            {
                //sub
            }
        }

        public void EndingACall(object sender, string callingNumber)
        {

        }

        public void AnsweringACall(object sender, AnswerACall args)
        {

        }

        public void SwitchPortState(object sender, PortCondition portCondition)
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

        public bool CheckSelfNumber(string callerNumber, string callingNumber)
        {
            bool equalNumbers = true;

            if(callerNumber != callingNumber)
            {
                equalNumbers = false;
            }

            return equalNumbers;
        }
    }
}
