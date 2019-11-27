using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements.SentenceElements;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainParser
{
    public class Parser :IParser
    {
        public Text ParseText(StreamReader sr) //мб внутри на методы больше раскинуть
        {
            IList<Sentence> textSentences = new List<Sentence>();

            Text text = new Text(textSentences);

            string allText = sr.ReadToEnd();

            ReplaceSpacesAndTabulation(ref allText);

            string[] arraySentences = Regex.Split(allText, @"(?<=[\.\!\?])");
            Array.Resize(ref arraySentences, arraySentences.Length - 1); //баш с нулевым предложением в конце текста исправление

            foreach (string sentence in arraySentences)
            {
                IList<Word> sentenceWords = new List<Word>();

                Sentence _sentence = new Sentence(sentenceWords);

                string[] arrayWords = sentence.Split(Word.WordsSeparators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in arrayWords)
                {
                    Word sentenceWord = new Word(word);

                    _sentence.AddWordToSentence(sentenceWord);
                }

                text.Sentences.Add(_sentence);
            }

            return text;
        }


        private void ReplaceSpacesAndTabulation(ref string text)
        {
            text = Regex.Replace(text, @"\s+", " ");
        }
    }
}
