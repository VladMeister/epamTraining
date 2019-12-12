using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.EventCallArgs
{
    public class AnswerACall : EventArgs
    {
        public string PhoneNumber { get; private set; }
        public string IncomingNumber { get; private set; }

        public AnswerACall(string phoneNumber, string incomingNumber)
        {
            PhoneNumber = phoneNumber;
            IncomingNumber = incomingNumber;
        }
    }
}
