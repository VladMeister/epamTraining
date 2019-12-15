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

        public void TryToConnect(string callingToNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                TryMakeCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingToNumber));
            }
            else
            {
                Console.WriteLine("Terminal is not connected!");
            }
        }

        public void SuccessfulCall(object sender, CallEventArgs callArgs) //double check???
        {
            MakeCallEvent?.Invoke(this, callArgs);
        }

        public void CallAnswer(string callingFromNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                AnswerCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingFromNumber));
            }
            else
            {
                Console.WriteLine("Terminal is not connected!");
            }
        }

        public void CallEnd(string callingNumber)
        {
            if (TerminalState == TerminalState.Connected)
            {
                EndCallEvent?.Invoke(this, new CallEventArgs(PhoneNumber, callingNumber));
            }
            else
            {
                Console.WriteLine("Terminal is not connected!");
            }
        }
    }
}
