using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements;
using System.IO;

namespace Task2Pershukevich.MainParser
{
    public interface IParser
    {
        Text ParseText(StreamReader sr);
        Sentence ParseSentence(Sentence sentence);
    }
}
