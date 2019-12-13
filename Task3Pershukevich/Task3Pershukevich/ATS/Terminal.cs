using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.EventCallArgs;

namespace Task3Pershukevich.ATS
{
    public class Terminal
    {
        public event EventHandler<MakeACall> MakeACallEvent;
        public event EventHandler<AnswerACall> AnswerACallEvent;
        public event EventHandler<string> EndACallEvent;


        public string PhoneNumber { get; private set; }
        public int IdNumber { get; private set; }

        public Terminal(string number, int idNum)
        {
            PhoneNumber = number;
            IdNumber = idNum;
        }

        public void TryMakeACall(string callingToNumber)
        {
            MakeACall makeACall = new MakeACall(PhoneNumber, callingToNumber);
            MakeACallEvent?.Invoke(this, makeACall);
        }

        public void AnswerACall(string callingFromNumber)
        {
            AnswerACall answerACall = new AnswerACall(PhoneNumber, callingFromNumber);
            AnswerACallEvent?.Invoke(this, answerACall);
        }

        public void EndACall(string callingNumber)
        {
            EndACallEvent?.Invoke(this, callingNumber);
        }
    }
}
