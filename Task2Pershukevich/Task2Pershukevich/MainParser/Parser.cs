using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;

namespace Task2Pershukevich.MainParser
{
    public class Parser :IParser
    {
        private string path { get; } 

        public Parser(string source)
        {
            path = source;
        }

        public Text Parse()
        {
            Text text = new Text();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(Regex.Replace(line, "[ ]+", " "));
                }
            }

            return text;
        }
    }
}
