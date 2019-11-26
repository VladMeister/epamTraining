using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public abstract class Symbol
    {
        public char _Symbol { get; protected set; }

        protected Symbol(char symbol)
        {
            _Symbol = symbol;
        }
    }
}
