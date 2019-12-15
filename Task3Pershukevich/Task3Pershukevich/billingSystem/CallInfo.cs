using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.billingSystem
{
    public enum CallType
    {
        Incoming,
        Outgoing
    }

    public class CallInfo
    {
        public CallType CallType { get; }
        public int Cost { get; set; }
        public DateTime StartCallDate { get; }
        public DateTime EndCallDate { get; set; }
        public TimeSpan CallLength { get; set; }
        public string CallingToNumber { get; }
        public string CallingFromNumber { get; }

        public CallInfo(CallType type, string sourceNumber, string destinationNumber)
        {
            CallType = type;
            CallingToNumber = destinationNumber;
            CallingFromNumber = sourceNumber;
            StartCallDate = DateTime.Now.Date;
        }
    }
}
