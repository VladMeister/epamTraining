using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class Word
    {
        public static string[] WordsSeparators = { ",", " – ", " - ", " ", ".", "!", "?", "...", "?!", "!?" };

        public string Symbols { get; }

        public Word(string symbols)
        {
            Symbols = symbols;
        }
    }
}
