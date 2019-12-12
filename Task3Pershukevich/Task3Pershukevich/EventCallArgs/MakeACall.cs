using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.EventCallArgs
{
    public class MakeACall : EventArgs
    {
        public string PhoneNumber { get; private set; }
        public string DestintionNumber { get; private set; }

        public MakeACall(string phoneNumber, string destinationNumber)
        {
            PhoneNumber = phoneNumber;
            DestintionNumber = destinationNumber;
        }
    }
}
