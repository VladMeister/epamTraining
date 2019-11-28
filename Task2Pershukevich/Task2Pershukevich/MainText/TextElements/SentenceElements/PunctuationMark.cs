﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class PunctuationMark : SentenceElement
    {
        private char mark { get; }

        public PunctuationMark(char symbol)
        {
            mark = symbol;
        }

        public override char GetFirstSymbol()
        {
            return mark;
        }
    }
}
