using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class CallEventArgs : EventArgs 
    {
        public string SourceNumber { get; }
        public string DestintionNumber { get; }
        public Guid TerminalSerialNumber { get; }

        public CallEventArgs(string sourceNumber, string destinationNumber)
        {
            SourceNumber = sourceNumber;
            DestintionNumber = destinationNumber;
        }

        public CallEventArgs(string sourceNumber, string destinationNumber, Guid terminalSerialNumber)
        {
            SourceNumber = sourceNumber;
            DestintionNumber = destinationNumber;
            TerminalSerialNumber = terminalSerialNumber;
        }
    }
}
