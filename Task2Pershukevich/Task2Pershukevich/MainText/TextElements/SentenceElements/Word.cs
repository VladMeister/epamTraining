using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class Word : SentenceElement
    {
        private IList<Symbol> symbols;

        public Word(IList<Symbol> _symbols)
        {
            symbols = _symbols;
        }

        public Word()
        {
            symbols = new List<Symbol>();
        }

        public void AddSymbolToWord(Symbol symbol)
        {
            symbols.Add(symbol);
        }

        public override char GetFirstSymbol()
        {
            return symbols[0]._Symbol;
        }

        public override string ToString()
        {
            string outputString = "";

            foreach(Symbol s in symbols)
            {
                outputString += s._Symbol;
            }

            return outputString;
        }
    }
}
