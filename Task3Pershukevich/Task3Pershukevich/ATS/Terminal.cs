using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.Exceptions;

namespace Task3Pershukevich.ATS
{
    public enum TerminalState
    {
        Connected,
        Disconnected
    }


    public class Terminal : ITerminal
    {
        public event EventHandler<CallEventArgs> TryToMakeCallEvent;
        public event EventHandler<CallEventArgs> MakeCallEvent;  //dial
        public event EventHandler<CallEventArgs> AnswerCallEvent;
        public event EventHandler<CallEventArgs> EndCallEvent;


        public string PhoneNumber { get; }
        public Guid SerialNumber { get; }
        public TerminalState TerminalState { get; private set; }

        public Terminal(string number)
        {
            PhoneNumber = number;
            SerialNumber = Guid.NewGuid();
            TerminalState = TerminalState.Disconnected;
        }

        public void ChangeTerminalState(object sender, PortChangeArgs stateArgs)
        {
            if(stateArgs.PortState == PortState.Busy || stateArgs.PortState == PortState.Free)
            {
                TerminalState = TerminalState.Connected;
            }
            else
            {
                TerminalState = TerminalState.Disconnected;
            }
        }

        public void MakeRing(string callingNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                TryToMakeCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber, SerialNumber));
            }
            else
            {
                throw new MakeCallException("Terminal is not connected!");
            }
        }

        public void MakeCall(object sender, CallEventArgs callArgs)
        {
            if(callArgs.TerminalSerialNumber == SerialNumber)
            {
                MakeCallEvent?.Invoke(this, callArgs);
            }
        }

        public void AnswerCall(string callingFromNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                AnswerCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingFromNumber));
            }
            else
            {
                throw new AnswerCallException("Terminal is not connected!");
            }
        }

        public void EndCall(string callingNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                EndCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber));
            }
            else
            {
                throw new EndCallException("Terminal is not connected!");
            }
        }
    }
}
