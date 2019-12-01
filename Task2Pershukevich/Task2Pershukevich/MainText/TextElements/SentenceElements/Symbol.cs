using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class Symbol
    {
        public char symbolElement { get; private set; }

        public Symbol(char symbol)
        {
            symbolElement = symbol;
        }
    }
}
