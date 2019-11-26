using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainParser
{
    public class Parser :IParser
    {
        public Text ParseText(StreamReader sr)
        {
            Text text = new Text();

            ReplaceSpacesAndTabulation(sr);

            //string line;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    for (int i = 0; i < line.Length; i++)
            //    {

            //    }
            //}

            return text;
        }

        public Sentence ParseSentence(Sentence sentence)
        {

            return sentence;
        }

        private void ReplaceSpacesAndTabulation(StreamReader sr)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(Regex.Replace(line, "[ ]+", " "));
            }
        }
    }
}
