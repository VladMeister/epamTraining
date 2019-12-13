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

        public void TryToConnect(string callingToNumber)
        {
            CallEventArgs makeCall = new CallEventArgs(PhoneNumber, callingToNumber);
            MakeCallEvent?.Invoke(this, makeCall);
        }

        public void SuccessfulCall()
        {
            //subscribing to chech ability in ats
        }

        public void CallAnswer(string callingFromNumber)
        {
            CallEventArgs answerCall = new CallEventArgs(PhoneNumber, callingFromNumber);
            AnswerCallEvent?.Invoke(this, answerCall);
        }

        public void CallEnd(string callingNumber)
        {
            CallEventArgs endCall = new CallEventArgs(PhoneNumber, callingNumber);
            EndCallEvent?.Invoke(this, endCall);
        }
    }
}
