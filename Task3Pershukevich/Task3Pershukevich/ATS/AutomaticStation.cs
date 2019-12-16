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

            _terminalContractMapping.Add(terminal, contract);

            return terminal;
        }

        public Port AssignToTerminalNewPort(Terminal terminal, Port port)
        {
            Port newPort = port;

            terminal.ChangeTerminalState += newPort.ChangePortState;
            newPort.ChangePortStateEvent += SwitchPortState;

            terminal.DialEvent += newPort.MakeRing;
            terminal.PickUpEvent += newPort.AnswerCall;
            terminal.HangUpEvent += newPort.EndCall;

            newPort.TryToMakeCallEvent += EstablishConnection;
            newPort.MakeCallEvent += HandlingOutgoingCall;
            newPort.AnswerCallEvent += HandlingIncomingCall;
            newPort.EndCallEvent += HandlingEndingCall;

            ConnectionAvailableEvent += newPort.MakeCall;


            _terminalPortMapping.Add(terminal, newPort);

            return newPort;
        }

        private void EstablishConnection(object sender, CallEventArgs callArgs)
        {
            if (CheckAvailabilityOfNumber(callArgs.DestintionNumber) && !IsSelfCall(callArgs.SourceNumber, callArgs.DestintionNumber))
            {
                ConnectionAvailableEvent?.Invoke(this, callArgs);
            }
            else
            {
                throw new EstablishConnectionException("An error occurred while creating the connection!");
            }
        }

        private void HandlingOutgoingCall(object sender, CallEventArgs callArgs)
        {
            ChangePortConditionByCall(callArgs.SourceNumber, PortState.Busy);
            ChangePortConditionByCall(callArgs.DestintionNumber, PortState.Busy);
            
            RecordCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Outgoing, callArgs.SourceNumber, callArgs.DestintionNumber));
        }

        private void HandlingEndingCall(object sender, CallEventArgs callArgs) 
        {
            ChangePortConditionByCall(callArgs.SourceNumber, PortState.Free);
            ChangePortConditionByCall(callArgs.DestintionNumber, PortState.Free);

            ChargeCallInfoEvent?.Invoke(this, new CallInfoArgs(callArgs.SourceNumber, callArgs.DestintionNumber));
        }

        private void HandlingIncomingCall(object sender, CallEventArgs callArgs)
        {
            if (CheckAvailabilityOfNumber(callArgs.DestintionNumber) && !IsSelfCall(callArgs.SourceNumber, callArgs.DestintionNumber))
            {
                ChangePortConditionByCall(callArgs.SourceNumber, PortState.Busy);
                ChangePortConditionByCall(callArgs.DestintionNumber, PortState.Busy);

                RecordCallInfoEvent?.Invoke(this, new CallInfoArgs(CallType.Incoming, callArgs.SourceNumber, callArgs.DestintionNumber));
            }
            else
            {
                throw new EstablishConnectionException("An error occurred while creating the connection!");
            }
        }

        private void SwitchPortState(object sender, PortChangeArgs stateArgs)
        {
            ChangePortConditionByPort(stateArgs.PortId, stateArgs.PortState);
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

        private Port GetPortByTerminalId(string phoneNumber)
        {
            return _terminalPortMapping.Where(x => x.Key.PhoneNumber == phoneNumber).Select(x => x.Value).Single();
        }

        private Port GetPortByPortId(int portId)
        {
            return _terminalPortMapping.Where(x => x.Value.PortId == portId).Select(x => x.Value).Single();
        }

        private void ChangePortConditionByCall(string phoneNumber, PortState state)
        {
            Port port = GetPortByTerminalId(phoneNumber);

            port.PortState = state;
        }

        private void ChangePortConditionByPort(int portId, PortState state)
        {
            Port port = GetPortByPortId(portId);

            port.PortState = state;
        }
    }
}
