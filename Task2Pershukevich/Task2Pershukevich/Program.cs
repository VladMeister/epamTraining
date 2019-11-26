using System;
using System.Collections.Generic;
using System.IO;
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

            Parser parser = new Parser();

            using (FileStream fs = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                parser.Parse(sr);
            }

                Console.ReadKey();
        }
    }
}
