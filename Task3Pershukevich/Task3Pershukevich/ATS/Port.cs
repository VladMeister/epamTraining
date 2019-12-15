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
        public event EventHandler<PortChangeArgs> ChangePortCondition;

        public PortState PortState { get; set; }
        public int PortId { get; private set; }

        public Port(int newId)
        {
            PortState = PortState.Off;
            PortId = newId;
        }
        
        public void PlugInTerminal()
        {
            PortState = PortState.Free;
            ChangePortCondition?.Invoke(this, new PortChangeArgs(PortId, PortState));
        }

        public void ChangeState(PortState portState)
        {
            PortState = portState;
            ChangePortCondition?.Invoke(this, new PortChangeArgs(PortId, PortState));
        }
    }
}
