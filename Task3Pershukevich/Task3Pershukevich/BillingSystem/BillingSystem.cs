using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.ATS;

namespace Task3Pershukevich.billingSystem
{
    public class BillingSystem : IBillingSystem
    {
        private IList<CallInfo> callDataList;

        public BillingSystem()
        {
            callDataList = new List<CallInfo>();
        }

        public void AddCallData(object sender, CallInfoArgs infoArgs)
        {
            CallInfo callInfo = new CallInfo(infoArgs.CallType, infoArgs.CallNumber);

            callDataList.Add(callInfo);
        }
    }
}
