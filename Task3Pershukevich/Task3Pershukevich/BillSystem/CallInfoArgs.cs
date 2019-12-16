using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BillSystem
{
    public class CallInfoArgs : EventArgs
    {
        public CallType CallType { get; }
        public string CallingToNumber { get; }
        public string CallingFromNumber { get; }

        public CallInfoArgs(CallType type, string sourceNumber, string destinationNumber)
        {
            CallType = type;
            CallingToNumber = destinationNumber;
            CallingFromNumber = sourceNumber;
        }

        public CallInfoArgs(string sourceNumber, string destinationNumber)
        {
            CallingToNumber = destinationNumber;
            CallingFromNumber = sourceNumber;
        }
    }
}
