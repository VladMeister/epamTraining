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
        private string sentencePunctAppConfig = ConfigurationManager.AppSettings["sentencePunctuationMarks"];
        private string wordsSeparatorsAppConfig = ConfigurationManager.AppSettings["wordsSeparators"];


        public string SourcePath { get; }
        private StreamReader streamReader; 
        private bool disposed = false;

        public TextParser(string path)
        {
            SourcePath = path;
        }

        public override Text ParseText() 
        {
            Text text = new Text();

            string sentence; // one line = one sentence

            try
            {
                using (streamReader = new StreamReader(SourcePath))
                {
                    while ((sentence = streamReader.ReadLine()) != null)
                    {
                        Sentence textSentence = new Sentence();

                        sentence = FixSpacesAndTabulation(sentence);

                        textSentence.SentenceType = Sentence.SetType(sentence.Last());  //setting type of sentence

                        GetPunctuationFromSentence(textSentence, sentence, sentencePunctAppConfig);  //getting punct marks and their positions

                        string[] arrayWords = sentence.Split(wordsSeparatorsAppConfig.Split('/'), StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in arrayWords)
                        {
                            Word sentenceWord = Word.CreateWordFromString(word);

                            textSentence.Add(sentenceWord);
                        }
                        
                        text.Add(textSentence);
                    }
                }
            }
            catch(Exception ex) { throw ex; }

            return text;
        }


        private string FixSpacesAndTabulation(string line)
        {
            line = Regex.Replace(line, @"\s+", " ");
            return line;
        }

        private void GetPunctuationFromSentence(Sentence textSentence, string sentence, string punctuationAppConfig)  
        {
            int currentPosition = 0;
            foreach (char symb in sentence)
            {
                if (punctuationAppConfig.Contains(symb))
                {
                    textSentence.AddPunctuation(symb, currentPosition); 
                }
                currentPosition++;
            }
        }

        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    if(streamReader != null)
                    {
                        streamReader.Dispose();
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
