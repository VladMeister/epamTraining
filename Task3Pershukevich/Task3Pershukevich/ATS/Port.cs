using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.Exceptions;

namespace Task3Pershukevich.ATS
{
    public enum PortState
    {
        Free,
        Off,
        Busy
    }

    public class Port
    {
        public event EventHandler<CallEventArgs> TryToMakeCallEvent;
        public event EventHandler<CallEventArgs> MakeCallEvent;
        public event EventHandler<CallEventArgs> AnswerCallEvent;
        public event EventHandler<CallEventArgs> EndCallEvent;

        public event EventHandler<PortChangeArgs> ChangePortStateEvent;

        public PortState PortState { get; set; }
        public int PortId { get; private set; }

        public Port(int newId)
        {
            PortState = PortState.Off;
            PortId = newId;
        }

        public void ChangePortState(object sender, TerminalChangeArgs stateArgs)
        {
            if (stateArgs.TerminalState == TerminalState.Connected)
            {
                PortState = PortState.Free;
                ChangePortStateEvent?.Invoke(this, new PortChangeArgs(PortId, PortState));
            }
            else
            {
                PortState = PortState.Off;
                ChangePortStateEvent?.Invoke(this, new PortChangeArgs(PortId, PortState));
            }
        }

        public void MakeRing(object sender, CallEventArgs callArgs)
        {
            if (PortState == PortState.Free)
            {
                TryToMakeCallEvent?.Invoke(this, new CallEventArgs(callArgs.SourceNumber,callArgs.DestintionNumber, PortId));
            }
            else
            {
                throw new MakeCallException("Terminal is not connected!");
            }
        }

        public void MakeCall(object sender, CallEventArgs callArgs)
        {
            if (callArgs.PortId == PortId)
            {
                MakeCallEvent?.Invoke(this, callArgs);
            }
        }

        public void AnswerCall(object sender, CallEventArgs callArgs)
        {
            if (PortState == PortState.Free)
            {
                AnswerCallEvent?.Invoke(this, callArgs);
            }
            else
            {
                throw new AnswerCallException("Terminal is not connected!");
            }
        }

        public void EndCall(object sender, CallEventArgs callArgs)
        {
            if (PortState == PortState.Busy)
            {
                EndCallEvent?.Invoke(this, callArgs);
            }
            else
            {
                throw new AnswerCallException("Terminal is not in call!");
            }
        }
    }
}
