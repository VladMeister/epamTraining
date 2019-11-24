using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Text Parse(string path)
        {
            Text text = new Text();

            return text;
        }
    }
}
