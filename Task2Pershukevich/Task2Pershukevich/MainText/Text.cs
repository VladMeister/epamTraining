using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainText
{
    public class Text : ICollection<Sentence>
    {
        public int Count => sentences.Count;

        public bool IsReadOnly => throw new NotImplementedException(); //no implementation


        private IList<Sentence> sentences; //весб текст Tostring

        public Text(IList<Sentence> _sentences)
        {
            sentences = _sentences;
        }

        public Text()
        {
            sentences = new List<Sentence>();
        }

        public IEnumerable<Sentence> OrderSentencesByCountOfWords() //1
        {
            return sentences.OrderBy(x => x.GetAllWordsFromSentence().Count);
        }

        public IEnumerable<Sentence> GetWordsFromInterrogativeSentences(int wordLenght) //2
        {
            return sentences.Where(x => x.ReturnSentenceType() == SentenceType.Interrogative);
                //.Where(s => s.Words.Where(w => w.Symbols.Count == lenght));
        }

        //public IEnumerable<Sentence> DeleteWordsStartingFromConsonant(int wordLenght) //3
        //{
        //    return sentences.Where(x => x.Words.Where(w => w.Symbols.Count == wordLenght));
        //}

        //public IEnumerable<Sentence> ChangeWordInConcreteSentence(int numberOfSentence, int wordsLenght, string subString) //4
        //{

        //}

        public ICollection<Sentence> GetAllSentencesFromText()
        {
            return sentences;
        }

        public void Add(Sentence sentence)
        {
            sentences.Add(sentence);
        }

        public void RemoveSentence(Sentence sentence)
        {
            sentences.Remove(sentence);
        }

        public void Clear()
        {
            sentences.Clear();
        }

        public bool Contains(Sentence item)
        {
            bool isContaining = false;

            if(sentences.Contains(item))
            {
                isContaining = true;
            }

            return isContaining;
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            sentences.CopyTo(array, arrayIndex);
        }

        bool ICollection<Sentence>.Remove(Sentence item)
        {
            bool isRemoved = false;

            if(sentences.Remove(item))
            {
                isRemoved = true;
            }

            return isRemoved;
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return GetAllSentencesFromText().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
