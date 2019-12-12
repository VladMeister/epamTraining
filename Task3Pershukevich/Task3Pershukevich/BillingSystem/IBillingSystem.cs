using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BillingSystem
{
    interface IBillingSystem
    {
        void AddCallData(CallType callType, string number);
    }
}
