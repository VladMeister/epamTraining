using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements.SentenceElements;

namespace Task2Pershukevich.MainText.TextElements
{
    public enum SentenceType
    {
        Declarative, //.
        Interrogative, //?
        Exclamatory, //!
        Continious //...
    }

    public class Sentence
    {
        private IList<Word> words { get; set; }
        private IList<PunctuationMark> punctuationMarks { get; set; }
        public SentenceType SentenceType { get; private set; }

        public void AddWordToSentence(IList<Symbol> word)
        {
            Word newWord = new Word(word);
            words.Add(newWord);
        }

        public void AddPunctuationToSentence(Symbol mark)
        {
            PunctuationMark punctuationMark = new PunctuationMark(mark);
            punctuationMarks.Add(punctuationMark);
        }

    }
}
