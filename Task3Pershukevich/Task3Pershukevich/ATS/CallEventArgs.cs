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
        public int PortId { get; }

        public CallEventArgs(string sourceNumber, string destinationNumber)
        {
            SourceNumber = sourceNumber;
            DestintionNumber = destinationNumber;
        }

        public CallEventArgs(string sourceNumber, string destinationNumber, int portId)
        {
            SourceNumber = sourceNumber;
            DestintionNumber = destinationNumber;
            PortId = portId;
        }
    }
}
