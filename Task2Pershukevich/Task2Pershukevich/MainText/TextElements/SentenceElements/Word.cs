using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class Word
    {
        private IList<Symbol> symbols { get; }

        public Word(IList<Symbol> symbols)
        {
            this.symbols = symbols;
        }
    }
}
