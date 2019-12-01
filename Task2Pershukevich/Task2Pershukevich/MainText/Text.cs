using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements;
using Task2Pershukevich.MainText.TextElements.SentenceElements;

namespace Task2Pershukevich.MainText
{
    public class Text : ICollection<Sentence>
    {
        public int Count => sentences.Count;

        public bool IsReadOnly => false; 


        private IList<Sentence> sentences; 

        public Text(IList<Sentence> sentencesList)
        {
            sentences = sentencesList;
        }

        public Text()
        {
            sentences = new List<Sentence>();
        }

        public IEnumerable<Sentence> OrderSentencesByCountOfWords() 
        {
            return sentences.OrderBy(x => x.GetAllWords().Count);
        }

        public IEnumerable<Sentence> GetInterrogativeSentences() 
        {
            return sentences.Where(x => x.SentenceType == SentenceType.Interrogative);
        }

        public Sentence GetConcreteSentence(int numberOfSentence)
        {
            return sentences[numberOfSentence];
        }

        public ICollection<Sentence> GetAllSentences()
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
            return GetAllSentences().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
