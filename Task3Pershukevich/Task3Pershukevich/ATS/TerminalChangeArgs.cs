using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class TerminalChangeArgs : EventArgs
    {
        public Guid TerminalSerialNumber { get; }
        public TerminalState TerminalState { get; }

        public TerminalChangeArgs(Guid number, TerminalState state)
        {
            TerminalSerialNumber = number;
            TerminalState = state;
        }
    }
}
