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
        public event EventHandler<CallEventArgs> DialEvent;
        public event EventHandler<CallEventArgs> PickUpEvent;
        public event EventHandler<CallEventArgs> HangUpEvent;

        public event EventHandler<TerminalChangeArgs> ChangeTerminalState;


        public string PhoneNumber { get; }
        public Guid SerialNumber { get; }
        public TerminalState TerminalState { get; set; }

        public Terminal(string number)
        {
            PhoneNumber = number;
            SerialNumber = Guid.NewGuid();
            TerminalState = TerminalState.Disconnected;
        }

        public void PlugInPort()
        {
            TerminalState = TerminalState.Connected;
            ChangeTerminalState?.Invoke(this, new TerminalChangeArgs(SerialNumber, TerminalState));
        }

        public void PlugOutPort()
        {
            TerminalState = TerminalState.Disconnected;
            ChangeTerminalState?.Invoke(this, new TerminalChangeArgs(SerialNumber, TerminalState));
        }

        public void MakeRing(string callingNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                DialEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber));
            }
            else
            {
                throw new MakeCallException("Terminal is not connected!");
            }
        }

        public void AnswerCall(string callingFromNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                PickUpEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingFromNumber));
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
                HangUpEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber));
            }
            else
            {
                throw new EndCallException("Terminal is not connected!");
            }
        }
    }
}
