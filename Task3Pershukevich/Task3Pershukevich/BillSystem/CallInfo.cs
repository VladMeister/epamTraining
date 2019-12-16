using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BillSystem
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
        public int CallLength { get; set; }
        public string CallingToNumber { get; }
        public string CallingFromNumber { get; }

        public CallInfo(CallType type, string sourceNumber, string destinationNumber)
        {
            CallType = type;
            CallingToNumber = destinationNumber;
            CallingFromNumber = sourceNumber;
            StartCallDate = DateTime.Now;
        }

        public string GetReportCallInfo()
        {
            return $"Call length - {CallLength}, Call price - {Cost}, Call abonent - {CallingFromNumber}";
        }

        public override string ToString()
        {
            return $"Call type - {CallType}, Cost - {Cost}, Call length - {CallLength} seconds, Call start - {StartCallDate.ToString("hh:mm:ss")}, Call End - {EndCallDate.ToString("hh:mm:ss")}";
        }
    }
}
