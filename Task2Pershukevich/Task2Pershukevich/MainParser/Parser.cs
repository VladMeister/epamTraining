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
        public Text Parse(StreamReader sr)
        {
            Text text = new Text();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(Regex.Replace(line, "[ ]+", " "));
                }

            return text;
        }
    }
}
