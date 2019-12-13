using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.billingSystem;

namespace Task3Pershukevich.ATS
{
    public class AutomaticStation : IAutomaticStation
    {
        private BillingSystem _billingSystem;

        private IList<Contract> _contractList;

        private IDictionary<Terminal, Port> _terminalPortMapping;
        private IDictionary<Terminal, Contract> _terminalContractMapping;

        //public event EventHandler fillBS;
        //public event EventHandler checkedAbilityToCall;

        public AutomaticStation()
        {
            _billingSystem = new BillingSystem();
            _contractList = new List<Contract>();
            _terminalPortMapping = new Dictionary<Terminal, Port>();
            _terminalContractMapping = new Dictionary<Terminal, Contract>();

            //bs event subscribes to meth
        }

        public void CreateNewContract(Client client, Tariff tariff, string phoneNumber)
        {
            Contract contract = new Contract(client, tariff, phoneNumber);

            _contractList.Add(contract);
        }

        public void AddNewTerminal(Contract contract, string phoneNumber)
        {
            Terminal terminal = new Terminal(phoneNumber);

            terminal.MakeCallEvent += EstablishConnection;
            terminal.AnswerCallEvent += AnsweringACall;
            terminal.EndCallEvent += EndingACall;

            _terminalContractMapping.Add(terminal, contract);
        }

        public void AddNewPort(Terminal terminal, Port port)
        {
            Port newPort = port;
            newPort.ChangePortCondition += SwitchPortState;

            _terminalPortMapping.Add(terminal, newPort);
        }

        private void EstablishConnection(object sender, CallEventArgs args)
        {
            if (CheckAvailabilityOfNumber(args.DestintionNumber) && CheckSelfNumber(args.PhoneNumber, args.DestintionNumber))
            {

            }
            //event creating where terminal subs
            //if failed to connect throw exeption, handling in main
        }

        private void EndingACall(object sender, CallEventArgs args) 
        {

        }

        private void AnsweringACall(object sender, CallEventArgs args)
        {

        }

        private void SwitchPortState(object sender, PortState portState)
        {
            
        }

        public bool CheckAvailabilityOfNumber(string callingNumber)
        {
            bool numberIsFree = false;

            if (ExistNumber(callingNumber))
            {
                numberIsFree = _terminalPortMapping.Where(x => x.Key.PhoneNumber == callingNumber).Any(x => x.Value.PortState == PortState.Free); //sep meth
            }

            return numberIsFree;
        }

        public bool ExistNumber(string callingNumber)
        {
            bool numberExists = false;

            if (_terminalContractMapping.Any(x => x.Key.PhoneNumber == callingNumber))
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
