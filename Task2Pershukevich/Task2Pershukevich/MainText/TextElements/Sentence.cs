using System;
using System.Collections;
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
    }

    public class Sentence : ICollection<Word>
    {
        public int Count => words.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public static string[] WordsSeparators = { ",", " – ", " - ", " ", ".", "!", "?" };


        private IList<Word> words; 
        public Dictionary<int, PunctuationMark> PunctuationMarks { get; private set; }
        public SentenceType SentenceType { get; private set; }

        public Sentence(IList<Word> _words)
        {
            words = _words;
        }

        public Sentence()
        {
            words = new List<Word>();
        }

        public void AddPunctuationToSentence(char mark, int position)
        {
            PunctuationMark punctuationMark = new PunctuationMark(mark);
            PunctuationMarks.Add(position, punctuationMark);
        }

        public ICollection<Word> GetAllWordsFromSentence()
        {
            return words;
        }

        public void Add(Word word)
        {
            words.Add(word);
        }

        public void Clear()
        {
            words.Clear();
        }

        public bool Contains(Word item)
        {
            bool isContaining = false;

            if (words.Contains(item))
            {
                isContaining = true;
            }

            return isContaining;
        }

        public void CopyTo(Word[] array, int arrayIndex)
        {
            words.CopyTo(array, arrayIndex);
        }

        public bool Remove(Word item)
        {
            bool isRemoved = false;

            if (words.Remove(item))
            {
                isRemoved = true;
            }

            return isRemoved;
        }

        public IEnumerator<Word> GetEnumerator()
        {
            return GetAllWordsFromSentence().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
