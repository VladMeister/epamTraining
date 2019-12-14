using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public enum TerminalState
    {
        Connected,
        Disconnected
    }


    public class Terminal
    {
        public event EventHandler<CallEventArgs> TryMakeCallEvent;
        public event EventHandler<CallEventArgs> MakeCallEvent;
        public event EventHandler<CallEventArgs> AnswerCallEvent;
        public event EventHandler<CallEventArgs> EndCallEvent;


        public string PhoneNumber { get; private set; }
        public Guid SerialNumber { get; }
        public TerminalState TerminalState { get; private set; }

        public Terminal(string number)
        {
            PhoneNumber = number;
            SerialNumber = Guid.NewGuid();
            TerminalState = TerminalState.Disconnected;
        }

        public void ChangeTerminalState(object sender, PortState state)
        {
            if(state == PortState.Busy || state == PortState.Free)
            {
                TerminalState = TerminalState.Connected;
            }
            else
            {
                TerminalState = TerminalState.Disconnected;
            }
        }

        public void TryToConnect(string callingToNumber)
        {
            TryMakeCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingToNumber));
        }

        public void SuccessfulCall(object sender, CallEventArgs callArgs)
        {
            MakeCallEvent?.Invoke(this, callArgs);
        }

        public void CallAnswer(string callingFromNumber)
        {
            AnswerCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingFromNumber));
        }

        public void CallEnd(string callingNumber)
        {
            EndCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber));
        }
    }
}
