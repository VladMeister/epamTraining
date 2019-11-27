using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainText
{
    public class Text : ISentencesManager
    {
        public IList<Sentence> Sentences { get; private set; } //весб текст Tostring

        public Text(IList<Sentence> sentences)
        {
            Sentences = sentences;
        }

        public Text()
        {

        }

        public void AddSentenceToText(Sentence sentence)
        {
            Sentences.Add(sentence);
        }

        public void RemoveSentenceFromText(Sentence sentence)
        {
            Sentences.Remove(sentence);
        }

        public void ClearAllSentences()
        {
            Sentences.Clear();
        }

        public IEnumerable<Sentence> SentencesByCountOfWords()
        {
            return Sentences.OrderBy(x => x.Words.Count);
        }
     }
}
