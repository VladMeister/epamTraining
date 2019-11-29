using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements.SentenceElements;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainParser
{
    public class TextParser : Parser, IDisposable
    {
        public string SourcePath { get; }
        public StreamReader SR { get; set; }
        private bool disposed = false;

        public TextParser(string path)
        {
            SourcePath = path;
            SR = new StreamReader(SourcePath);
        }

        public override Text ParseText() 
        {
            Text text = new Text();

            string sentence; // one line = one sentence

            while((sentence = SR.ReadLine()) != null)
            {
                Sentence textSentence = new Sentence();

                sentence = FixSpacesAndTabulation(sentence);

                textSentence.SetTypeOfSentence(GetTypeOfSentence(sentence.Last()));  //setting type of sentence

                GetPunctuationFromSentence(textSentence, sentence); //getting punct marks and their positions

                string[] arrayWords = sentence.Split(ConfigurationManager.AppSettings["wordsSeparators"]
                    .Split('/'), StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in arrayWords)
                {
                    Word sentenceWord = new Word();

                    foreach(char symbol in word)
                    {
                        Symbol wordSymbol = new Symbol(symbol);

                        sentenceWord.AddSymbolToWord(wordSymbol);
                    }

                    textSentence.Add(sentenceWord);
                }

                text.Add(textSentence);
            }

            return text;
        }


        private string FixSpacesAndTabulation(string line)
        {
            line = Regex.Replace(line, @"\s+", " ");
            return line;
        }

        private SentenceType GetTypeOfSentence(char lastSymbol)
        {
            SentenceType sentType = SentenceType.Declarative;

            switch(lastSymbol)
            {
                case '.':
                    sentType = SentenceType.Declarative;
                    break;
                case '?':
                    sentType = SentenceType.Interrogative;
                    break;
                case '!':
                    sentType = SentenceType.Exclamatory;
                    break;
                default:
                    sentType = SentenceType.Declarative;
                    break;
            }

            return sentType;
        }

        private void GetPunctuationFromSentence(Sentence textSentence, string sentence)  //вот тут ошибка в indexOf - видит первую и все
        {
            foreach (char symb in sentence)
            {
                if (ConfigurationManager.AppSettings["sentencePunctuationMarks"].Contains(symb))
                {
                    textSentence.AddPunctuationToSentence(symb, sentence.IndexOf(symb)); //<--
                }
            }
        }

        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    if(SR != null)
                    {
                        SR.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
