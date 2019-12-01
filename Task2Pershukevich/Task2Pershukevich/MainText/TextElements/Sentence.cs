using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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

        private IList<Word> words;
        private IList<PunctuationMark> punctuationMarks;
        private SentenceType sentenceType;

        public Sentence(IList<Word> _words)
        {
            words = _words;
        }

        public Sentence()
        {
            words = new List<Word>();
            punctuationMarks = new List<PunctuationMark>();
        }

        public ICollection<Word> GetAllWordsFromSentence()
        {
            return words;
        }

        public ICollection<PunctuationMark> GetPunctuationMarks()
        {
            return punctuationMarks;
        }

        public void AddPunctuationToSentence(char punctMark, int position)
        {
            PunctuationMark punctuationMark = new PunctuationMark(punctMark, position);
            punctuationMarks.Add(punctuationMark);
        }

        public void SetTypeOfSentence(SentenceType sentType)
        {
            sentenceType = sentType;
        }

        public SentenceType ReturnSentenceType()
        {
            return sentenceType;
        }

        public IEnumerable<Word> GetWordsFromInterrogativeSentences(int lenght)
        {
            return words.Where(w => w.GetWordsLenght() == lenght).Distinct(); //distinct is not working
        }

        public IEnumerable<Word> GetWordsStartingFromConsonant(int lenght)
        {
            return words.Where(x => x.GetWordsLenght() == lenght)
                .Where(w => ConfigurationManager.AppSettings["consonantLetters"].Contains(char.ToLower(w.GetFirstSymbol())));
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

        public override string ToString()
        {
            string outputString = "";

            foreach (Word word in words)
            {
                outputString += word.ToString() + " ";
            }

            foreach (PunctuationMark punctMark in punctuationMarks)
            {
                outputString = outputString.Insert(punctMark.GetPositionInSentence(), Convert.ToString(punctMark.GetFirstSymbol()));
            }

            return outputString;
        }
    }
}
