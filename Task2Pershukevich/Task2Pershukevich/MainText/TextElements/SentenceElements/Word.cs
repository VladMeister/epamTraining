﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainText.TextElements.SentenceElements
{
    public class Word : SentenceElement, IEquatable<Word>
    {
        private IList<Symbol> symbols;

        public Word(IList<Symbol> symbolsList)
        {
            symbols = symbolsList;
        }

        public Word()
        {
            symbols = new List<Symbol>();
        }

        public static Word CreateWordFromString(string symbols)
        {
            Word word = new Word();

            foreach (char symbol in symbols)
            {
                Symbol wordSymbol = new Symbol(symbol);

                word.AddSymbol(wordSymbol);
            }

            return word;
        }

        public void AddSymbol(Symbol symbol)
        {
            symbols.Add(symbol);
        }

        public IEnumerable<Symbol> GetSymbols()
        {
            return symbols;
        }

        public int GetWordsLenght()
        {
            return symbols.Count;
        }

        public override char GetFirstSymbol()
        {
            return symbols[0].symbolElement;
        }

        public override string ToString() 
        {
            StringBuilder outputString = new StringBuilder();

            foreach(Symbol s in symbols)
            {
                outputString.Append(s.symbolElement);
            }

            return outputString.ToString();
        }

        public bool Equals(Word other)  //for correct distinct working 2)
        {
            if(ToString() == other.ToString())
            {
                return true;
            }
            
            return false;
        }

        public override int GetHashCode() //for correct distinct working 1)
        {
            int hashString = ToString() == null ? 0 : ToString().GetHashCode();

            return hashString;
        }
    }
}
