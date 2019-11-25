using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class PunctuationMark
    {
        private char punctuationMark { get; }

        public PunctuationMark(Symbol mark)
        {
            punctuationMark = mark._Symbol;
        }
    }
}
