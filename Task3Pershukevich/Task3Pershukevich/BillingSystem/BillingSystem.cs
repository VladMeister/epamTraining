using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.ATS;

namespace Task3Pershukevich.BillingSystem
{
    public class BillingSystem : IBillingSystem
    {
        private IList<CallInfo> callDataList;

        public BillingSystem()
        {
            callDataList = new List<CallInfo>();
        }

        public void AddCallData(CallType callType, string number)
        {
            CallInfo callInfo = new CallInfo(callType, number);

            callInfo.SetCostOfCall(callType);

            //end time of call

            callDataList.Add(callInfo);
        }
    }
}
