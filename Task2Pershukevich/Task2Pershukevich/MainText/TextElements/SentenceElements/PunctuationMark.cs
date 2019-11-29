using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class PunctuationMark : SentenceElement
    {
        private char mark { get; }
        private int positionInSentence { get; }

        public PunctuationMark(char symbol, int position)
        {
            mark = symbol;
            positionInSentence = position;
        }

        public override char GetFirstSymbol()
        {
            return mark;
        }

        public int GetPositionInSentence()
        {
            return positionInSentence;
        }
    }
}
