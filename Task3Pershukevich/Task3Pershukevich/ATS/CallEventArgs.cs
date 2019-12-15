﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class CallEventArgs : EventArgs 
    {
        public string PhoneNumber { get; }
        public string DestintionNumber { get; }

        public CallEventArgs(string phoneNumber, string destinationNumber)
        {
            PhoneNumber = phoneNumber;
            DestintionNumber = destinationNumber;
        }
    }
}
