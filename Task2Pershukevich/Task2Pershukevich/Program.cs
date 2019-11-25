using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainParser;

namespace Task2Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "../../text.txt";

            Parser parser = new Parser(sourcePath);
            parser.Parse();

            Console.ReadKey();
        }
    }
}
