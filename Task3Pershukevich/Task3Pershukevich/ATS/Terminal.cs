using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public class Terminal
    {
        public event EventHandler MakeACallEvent;
        public event EventHandler AnswerACallEvent;
        public event EventHandler<string> EndACallEvent;


        public string PhoneNumber { get; private set; }
        public int IdNumber { get; private set; }

        public Terminal(string number, int idNum)
        {
            PhoneNumber = number;
            IdNumber = idNum;
        }

        public void TryMakeACall(string toNumber)
        {
            //MakeACallEvent?.Invoke(this, PhoneNumber, toNumber);
        }

        public void AnswerACall(string fromNumber)
        {
            //AnswerACallEvent?.Invoke(this, PhoneNumber, fromNumber);
        }

        public void EndACall(string fromNumber)
        {
            EndACallEvent?.Invoke(this, fromNumber);
        }
    }
}
