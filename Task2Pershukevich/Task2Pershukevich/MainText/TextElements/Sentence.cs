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
        public IList<Word> Words { get; private set; }
        public Dictionary<int, PunctuationMark> PunctuationMarks { get; private set; }
        public SentenceType SentenceType { get; private set; }

        public void AddWordToSentence(char[] word)
        {
            Word newWord = new Word(word);
            Words.Add(newWord);
        }

        public void AddPunctuationToSentence(char mark, int position)
        {
            PunctuationMark punctuationMark = new PunctuationMark(mark);
            PunctuationMarks.Add(position, punctuationMark);
        }

        public void GetAllWordsFromSentence()
        {
            foreach(Word w in Words)
            {
                Console.WriteLine(w.Symbols);
            }
        }
    }
}
