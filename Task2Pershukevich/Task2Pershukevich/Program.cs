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

            Parser parser = new Parser();
            
            Text text = new Text();

            using (FileStream fs = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(fs))
            {
                text = parser.ParseText(sr);
            }

            //Console.WriteLine(text.Sentences.Count);

            //foreach (Sentence sent in text.Sentences) //all words returning
            //{
            //    sent.GetAllWordsFromSentence();
            //}

            foreach (Sentence sent in text.SentencesByCountOfWords()) //filter by count of words
            {
                Console.WriteLine($"Count of words in this sentence: {sent.Words.Count}");
                sent.GetAllWordsFromSentence();
            }

            Console.ReadKey();
        }
    }
}
