using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.billingSystem
{
    public class CallInfoArgs : EventArgs
    {
        public CallType CallType { get; }
        public string CallNumber { get; }

        public CallInfoArgs(CallType type, string number)
        {
            CallType = type;
            CallNumber = number;
        }
    }
}
