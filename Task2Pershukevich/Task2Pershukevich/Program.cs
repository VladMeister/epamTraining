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
        static void Main(string[] args) //закинуть все по методам
        {
            string sourcePath = "../../text.txt";

            TextParser parser = new TextParser(sourcePath);
            
            Text text = new Text();

            //using (FileStream fs = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //using (BufferedStream bs = new BufferedStream(fs))

            using (parser.SR = new StreamReader(parser.SourcePath))
            {
                text = parser.ParseText();
                //parser.Dispose();
            }

            //foreach (Sentence sent in text.GetAllSentencesFromText())  //every sentence to string
            //{
            //    Console.WriteLine(sent.ToString());
            //}

            //foreach (Sentence sent in text.GetAllSentencesFromText()) //amount of words in every sent
            //{
            //    Console.WriteLine(sent.GetAllWordsFromSentence().Count);
            //}

            //foreach (Sentence sent in text.GetAllSentencesFromText())  //every word output
            //{
            //    foreach (Word word in sent)
            //    {
            //        Console.WriteLine(word.ToString());
            //    }
            //}

            //foreach (Sentence sent in text.OrderSentencesByCountOfWords()) //filter by count of words
            //{
            //    Console.WriteLine($"Count of words in this sentence: {sent.GetAllWordsFromSentence().Count}");
            //    sent.GetAllWordsFromSentence();
            //}

            Console.ReadKey();
        }
    }
}
