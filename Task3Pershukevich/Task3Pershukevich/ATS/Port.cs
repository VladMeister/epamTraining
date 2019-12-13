using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public event EventHandler<PortState> ChangePortCondition;

        public PortState PortState { get; private set; }
        public int PortId { get; private set; }

        public Port(int newId)
        {
            PortState = PortState.Off;
            PortId = newId;
        }

        //plug in terminal + event maybe to change terminal state

        public void ChangeState(PortState portState)
        {
            PortState = portState;
            ChangePortCondition?.Invoke(this, PortState);
        }
    }
}
