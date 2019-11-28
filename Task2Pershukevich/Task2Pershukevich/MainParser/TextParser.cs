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
    public class TextParser : Parser
    {
        public string SourcePath { get; }
        public StreamReader SR { get; set; }

        public TextParser(string path)
        {
            SourcePath = path;
        }

        public override Text ParseText() 
        {
            Text text = new Text();

            string sentence; // one line = one sentence

            while((sentence = SR.ReadLine()) != null)
            {
                FixSpacesAndTabulation(sentence);

                Sentence textSentence = new Sentence();

                string[] arrayWords = sentence.Split(Sentence.WordsSeparators, StringSplitOptions.RemoveEmptyEntries);

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

            //string[] arraySentences = Regex.Split(allText, @"(?<=[\.\!\?])", RegexOptions.IgnoreCase);//<-
            //Array.Resize(ref arraySentences, arraySentences.Length - 1); //баш с нулевым предложением в конце текста исправление

            return text;
        }


        private void FixSpacesAndTabulation(string line)
        {
            line = Regex.Replace(line, @"\s+", " ");
        }
    }
}
