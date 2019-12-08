using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BS.BillingSystemElements
{
    public enum CallType
    {
        Incoming,
        Outgoing
    }

    public class CallData
    {
        public CallType callType { get; }
        public int Cost { get; private set; }
        public DateTime CallDate { get; }
        public int CallNumber { get; }

        public CallData(CallType type, int number)
        {
            callType = type;
            CallNumber = number;
            CallDate = DateTime.Now.Date;
        }

    }
}
