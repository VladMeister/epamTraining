using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class PortChangeArgs : EventArgs
    {
        public int PortId { get; }
        public PortState PortState { get; }

        public PortChangeArgs(int id, PortState state)
        {
            PortId = id;
            PortState = state;
        }
    }
}
