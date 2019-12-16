using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public interface ITerminal
    {
        void MakeRing(string callingNumber);
        void AnswerCall(string callingFromNumber);
        void EndCall(string callingNumber);
    }
}
