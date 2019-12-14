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
        public string CallNumber { get; }
        //maybe add tariff prop here

        public CallInfo(CallType type, string number)
        {
            CallType = type;
            CallNumber = number;
            StartCallDate = DateTime.Now.Date;
        }
    }
}
