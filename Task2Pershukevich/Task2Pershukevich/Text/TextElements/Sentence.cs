using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.Text.TextElements
{
    public class Sentence
    {
        private IList<Word> words { get; }
        private IList<PunctuationMark> punctuationMarks { get; }
        private char lastSymbol { get; set; }

        public void AddWordToSentence(char[] word)
        {
            Word newWord = new Word(word);
            words.Add(newWord);
        }

        public void AddPunctuationToSentence(char mark)
        {
            PunctuationMark punctuationMark = new PunctuationMark(mark);
            punctuationMarks.Add(punctuationMark);
        }

    }
}
