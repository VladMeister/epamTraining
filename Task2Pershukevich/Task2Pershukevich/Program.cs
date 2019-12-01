using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainParser;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements;
using Task2Pershukevich.MainText.TextElements.SentenceElements;

namespace Task2Pershukevich
{
    class Program
    {
        static void Main(string[] args) 
        {
            string sourcePath = "../../text.txt";

            TextParser parser = new TextParser(sourcePath);
            
            Text text = new Text();

            try
            {
                using (parser.SR = new StreamReader(parser.SourcePath))
                {
                    text = parser.ParseText();
                    parser.Dispose();
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            //FilterSentencesByCountOfWords(text);  //filter by count of words (1 exercise)

            //GetWordsByLenghtFromInterrogativeSentences(text, 6);  //words with given lenght from interrogative sentences (2 exercise)

            GetTextWithDeletedWordsStartingFromConsonant(text, 28);

            //




            //OutoutEveryPunctuationMark(text);  //every punctuation mark

            //OutputEverySentence(text);  //every sentence to string

            //OutputAmountOfWordsInEverySentence(text);  //amount of words in every sentence

            //OutputEveryWordFromText(text);  //every word output

            Console.ReadKey();
        }




        static void OutputEverySentence(Text text)
        {
            foreach (Sentence sent in text.GetAllSentencesFromText())
            {
                Console.WriteLine(sent.ToString());
            }
        }

        static void OutoutEveryPunctuationMark(Text text)
        {
            foreach (Sentence sent in text.GetAllSentencesFromText())  
            {
                foreach (PunctuationMark pm in sent.GetPunctuationMarks())
                {
                    Console.WriteLine(pm.GetFirstSymbol());
                }
            }
        }

        static void OutputAmountOfWordsInEverySentence(Text text)
        {
            foreach (Sentence sent in text.GetAllSentencesFromText()) 
            {
                Console.WriteLine(sent.GetAllWordsFromSentence().Count);
            }
        }

        static void OutputEveryWordFromText(Text text)
        {
            foreach (Sentence sent in text.GetAllSentencesFromText())  
            {
                foreach (Word word in sent)
                {
                    Console.WriteLine(word.ToString());
                }
            }
        }

        static void FilterSentencesByCountOfWords(Text text)
        {
            Console.WriteLine("Filtered count of words in every sentence: ");

            foreach (Sentence sent in text.OrderSentencesByCountOfWords())
            {
                Console.WriteLine(sent.GetAllWordsFromSentence().Count);
                sent.GetAllWordsFromSentence();
            }
        }

        static void GetWordsByLenghtFromInterrogativeSentences(Text text, int wordLenght)
        {
            Console.WriteLine($"Words with lenght = {wordLenght} in interrogative sentences: ");

            foreach (Sentence sent in text.GetInterrogativeSentences())
            {
                foreach (Word word in sent.GetWordsFromInterrogativeSentences(wordLenght))
                {
                    Console.WriteLine(word.ToString());
                }
            }
        }

        static void GetTextWithDeletedWordsStartingFromConsonant(Text text, int wordLenght)
        {
            Console.WriteLine($"Getting new text after deleting words with lenght = {wordLenght} in every sentence: ");

            foreach (Sentence sent in text.GetAllSentencesFromText())
            {
                foreach(Word word in sent.GetWordsStartingFromConsonant(wordLenght))
                {
                    //Console.WriteLine(word.ToString());
                    sent.Remove(word);
                }
            }

            text.GetAllSentencesFromText();
        }
    }
}
