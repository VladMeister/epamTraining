using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public abstract class Symbol
    {
        private char symbol { get; }

        protected Symbol(char symbol)
        {
            this.symbol = symbol;
        }
    }
}
