using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainParser;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements;
using Task2Pershukevich.MainText.TextElements.SentenceElements;
using Task2Pershukevich.MainWriter;

namespace Task2Pershukevich
{
    class Program
    {
        static void Main(string[] args) 
        {
            string sourcePath = "../../text.txt";
            string objectModelPath = "../../objectModel.txt";

            TextParser parser = new TextParser(sourcePath);
            
            Text text = new Text();

            try
            {
                using (parser) //<= ?
                {
                    text = parser.ParseText();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //FilterSentencesByCountOfWords(text);  //filter by count of words (exercise 1)

            //GetWordsByLenghtFromInterrogativeSentences(text, 6);  //words with given lenght from interrogative sentences (exercise 2)

            //GetTextWithDeletedWordsStartingFromConsonant(text, 9);  //deleting words with given lenght and starting with consonant from text (exercise 3)

            //GetTextWIthReplacedWordsInSentence(text, 19, 6, "amazing things");  //replacing words with given lenght in sentence with given substring (exercise 4)
            


            Writer writer = new Writer(objectModelPath);  //object model saving

            //try
            //{
            //    writer.Write(text);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //OutoutEveryPunctuationMark(text);  //every punctuation mark

            OutputEverySentence(text);  //every sentence to string

            //OutputAmountOfWordsInEverySentence(text);  //amount of words in every sentence

            //OutputEveryWordFromText(text);  //every word output

            Console.ReadKey();
        }




        static void OutputEverySentence(Text text)
        {
            foreach (Sentence sent in text.GetAllSentences())
            {
                Console.WriteLine(sent.ToString());
            }
        }

        static void OutoutEveryPunctuationMark(Text text)
        {
            foreach (Sentence sent in text.GetAllSentences())  
            {
                foreach (PunctuationMark pm in sent.GetPunctuationMarks())
                {
                    Console.WriteLine(pm.GetFirstSymbol());
                }
            }
        }

        static void OutputAmountOfWordsInEverySentence(Text text)
        {
            foreach (Sentence sent in text.GetAllSentences()) 
            {
                Console.WriteLine(sent.GetAllWords().Count);
            }
        }

        static void OutputEveryWordFromText(Text text)
        {
            foreach (Sentence sent in text.GetAllSentences())  
            {
                foreach (Word word in sent)
                {
                    Console.WriteLine(word.ToString());
                }
            }
        }


        static void FilterSentencesByCountOfWords(Text text)
        {
            Console.WriteLine("Filtered count of words in every sentence:");

            foreach (Sentence sent in text.OrderSentencesByCountOfWords())
            {
                //Console.WriteLine(sent.ToString());
                Console.WriteLine(sent.GetAllWords().Count);
            }
        }

        static void GetWordsByLenghtFromInterrogativeSentences(Text text, int wordLenght)
        {
            Console.WriteLine($"Words with lenght = {wordLenght} in interrogative sentences:");

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
            Console.WriteLine($"Getting text after deleting words starting with consonant with lenght = {wordLenght} in every sentence:");

            text.DeleteConsonantWordsFromSentences(wordLenght, ConfigurationManager.AppSettings["vowelLetters"]);
        }

        static void GetTextWIthReplacedWordsInSentence(Text text, int sentenceNumber, int wordLenght, string subString)
        {
            Console.WriteLine($"Getting text after replacing words with lenght = {wordLenght} in sentence №{sentenceNumber} with substring '{subString}':");

            text.GetConcreteSentence(sentenceNumber).ReplaceWordsWithSubstring(wordLenght, subString);
        }
    }
}
