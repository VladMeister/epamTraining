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

        public event EventHandler<CallInfoArgs> AddCallInfoEvent;
        public event EventHandler<CallEventArgs> AvailableConnectionEvent;

        public AutomaticStation()
        {
            _billingSystem = new BillingSystem();
            _contractList = new List<Contract>();
            _terminalPortMapping = new Dictionary<Terminal, Port>();
            _terminalContractMapping = new Dictionary<Terminal, Contract>();

            AddCallInfoEvent += _billingSystem.AddCallData;
        }

        public Contract CreateNewContract(Client client, Tariff tariff, string phoneNumber)
        {
            Contract contract = new Contract(client, tariff, phoneNumber);

            _contractList.Add(contract);

            return contract;
        }

        public Terminal AddNewTerminal(Contract contract, string phoneNumber)
        {
            Terminal terminal = new Terminal(phoneNumber);

            terminal.TryMakeCallEvent += EstablishConnection;
            terminal.MakeCallEvent += MakingCall;
            terminal.AnswerCallEvent += AnsweringCall;
            terminal.EndCallEvent += EndingCall;

            AvailableConnectionEvent += terminal.SuccessfulCall;

            _terminalContractMapping.Add(terminal, contract);

            return terminal;
        }

        public Port AddNewPort(Terminal terminal, Port port)
        {
            Port newPort = port;
            newPort.ChangePortCondition += SwitchPortState;
            newPort.ChangePortCondition += terminal.ChangeTerminalState;

            _terminalPortMapping.Add(terminal, newPort);

            return newPort;
        }

        private void EstablishConnection(object sender, CallEventArgs callArgs)
        {
            if (CheckAvailabilityOfNumber(callArgs.DestintionNumber) && CheckSelfNumber(callArgs.PhoneNumber, callArgs.DestintionNumber))
            {
                AvailableConnectionEvent?.Invoke(this, new CallEventArgs(callArgs.PhoneNumber, callArgs.DestintionNumber));
            }
            else
            {
                throw new Exception();
            }
        }

        private void MakingCall(object sender, CallEventArgs callArgs)
        {
            //change port states in all handlers
            AddCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Outgoing, callArgs.PhoneNumber));
        }

        private void EndingCall(object sender, CallEventArgs callArgs) 
        {
            AddCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Outgoing, callArgs.DestintionNumber)); //not needed call type?
        }

        private void AnsweringCall(object sender, CallEventArgs callArgs)
        {
            AddCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Incoming, callArgs.DestintionNumber));
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
