using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BillingSystem
{
    public enum CallType
    {
        Incoming,
        Outgoing
    }

    public class CallInfo
    {
        public CallType CallType { get; }
        public int Cost { get; private set; }
        public DateTime StartCallDate { get; }
        public DateTime EndCallDate { get; }
        public string CallNumber { get; }

        public CallInfo(CallType type, string number)
        {
            CallType = type;
            CallNumber = number;
            StartCallDate = DateTime.Now.Date;
        }

        public void SetCostOfCall(CallType callType)
        {
            if(callType == CallType.Incoming)
            {
                Cost = 0;
            }
            else
            {
                //Price calculate
            }
        }
    }
}
