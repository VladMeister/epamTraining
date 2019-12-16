using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.Exceptions;
using Task3Pershukevich.BillSystem;

namespace Task3Pershukevich.ATS
{
    public class AutomaticStation : IAutomaticStation
    {
        private BillingSystem _billingSystem;

        private IList<Contract> _contractList;

        private IDictionary<Terminal, Port> _terminalPortMapping;
        private IDictionary<Terminal, Contract> _terminalContractMapping;

        public event EventHandler<CallInfoArgs> RecordCallInfoEvent;
        public event EventHandler<CallInfoArgs> ChargeCallInfoEvent;

        public event EventHandler<CallEventArgs> ConnectionAvailableEvent;

        public AutomaticStation(BillingSystem billingSystem)
        {
            _billingSystem = billingSystem;
            _contractList = new List<Contract>();
            _terminalPortMapping = new Dictionary<Terminal, Port>();
            _terminalContractMapping = new Dictionary<Terminal, Contract>();

            RecordCallInfoEvent += _billingSystem.AddCallData;
            ChargeCallInfoEvent += _billingSystem.AddAfterCallInfo;
        }

        public Contract CreateNewContract(Client client, Tariff tariff, string phoneNumber)
        {
            Contract contract = new Contract(client, tariff, phoneNumber);

            _contractList.Add(contract);

            return contract;
        }

        public Terminal GiveNewTerminal(Contract contract, string phoneNumber)
        {
            Terminal terminal = new Terminal(phoneNumber);

            terminal.TryToMakeCallEvent += EstablishConnection;
            terminal.MakeCallEvent += HandlingOutgoingCall;
            terminal.AnswerCallEvent += HandlingIncomingCall;
            terminal.EndCallEvent += HandlingEndingCall;

            ConnectionAvailableEvent += terminal.MakeCall;

            _terminalContractMapping.Add(terminal, contract);

            return terminal;
        }

        public Port AssignToTerminalNewPort(Terminal terminal, Port port)
        {
            Port newPort = port;
            newPort.ChangePortState += SwitchPortState;
            newPort.ChangePortState += terminal.ChangeTerminalState;

            _terminalPortMapping.Add(terminal, newPort);

            return newPort;
        }

        private void EstablishConnection(object sender, CallEventArgs callArgs)
        {
            if (CheckAvailabilityOfNumber(callArgs.DestintionNumber) && !IsSelfCall(callArgs.SourceNumber, callArgs.DestintionNumber))
            {
                ConnectionAvailableEvent?.Invoke(this, new CallEventArgs(callArgs.SourceNumber, callArgs.DestintionNumber, callArgs.TerminalSerialNumber));
            }
            else
            {
                throw new EstablishConnectionException("An error occurred while creating the connection!");
            }
        }

        private void HandlingOutgoingCall(object sender, CallEventArgs callArgs)
        {
            //_terminalPortMapping = _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.SourceNumber).Select(x => { x.Value.PortState = PortState.Busy; return x; }).ToDictionary(); //sep meth
            _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.DestintionNumber).Select(x => { x.Value.PortState = PortState.Busy; return x; }).ToList();

            RecordCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Outgoing, callArgs.SourceNumber, callArgs.DestintionNumber));
        }

        private void HandlingEndingCall(object sender, CallEventArgs callArgs) 
        {
            _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.SourceNumber).Select(x => { x.Value.PortState = PortState.Free; return x; }).ToList();
            _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.DestintionNumber).Select(x => { x.Value.PortState = PortState.Free; return x; }).ToList();

            ChargeCallInfoEvent?.Invoke(this, new CallInfoArgs(callArgs.SourceNumber, callArgs.DestintionNumber));
        }

        private void HandlingIncomingCall(object sender, CallEventArgs callArgs)
        {
            if (CheckAvailabilityOfNumber(callArgs.DestintionNumber) && !IsSelfCall(callArgs.SourceNumber, callArgs.DestintionNumber))
            {
                _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.SourceNumber).Select(x => { x.Value.PortState = PortState.Busy; return x; }).ToList();
                _terminalPortMapping.Where(x => x.Key.PhoneNumber == callArgs.DestintionNumber).Select(x => { x.Value.PortState = PortState.Busy; return x; }).ToList();

                RecordCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Incoming, callArgs.SourceNumber, callArgs.DestintionNumber));
            }
            else
            {
                throw new EstablishConnectionException("An error occurred while creating the connection!");
            }
        }

        private void SwitchPortState(object sender, PortChangeArgs stateArgs)
        {
            _terminalPortMapping.Where(x => x.Value.PortId == stateArgs.PortId).Select(x => { x.Value.PortState = stateArgs.PortState; return x; }).ToList();
        }

        private bool CheckAvailabilityOfNumber(string callingNumber)
        {
            bool numberIsFree = false;

            if (ExistNumber(callingNumber))
            {
                numberIsFree = CheckPortState(callingNumber); 
            }

            return numberIsFree;
        }

        private bool ExistNumber(string callingNumber)
        {
            bool numberExists = false;

            if (CheckForExistingNumber(callingNumber))
            {
                numberExists = true;
            }

            return numberExists;
        }

        private bool IsSelfCall(string callerNumber, string callingNumber)
        {
            bool equalNumbers = true;

            if(callerNumber != callingNumber)
            {
                equalNumbers = false;
            }

            return equalNumbers;
        }

        private bool CheckForExistingNumber(string callingNumber)
        {
            return _terminalContractMapping.Any(x => x.Key.PhoneNumber == callingNumber);
        }

        private bool CheckPortState(string callingNumber)
        {
            return _terminalPortMapping.Where(x => x.Key.PhoneNumber == callingNumber).Any(x => x.Value.PortState == PortState.Free);
        }
    }
}
