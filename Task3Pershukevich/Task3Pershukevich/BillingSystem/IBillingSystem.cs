﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.billingSystem
{
    public interface IBillingSystem
    {
        void AddCallData(object sender, CallInfoArgs infoArgs);
    }
}
