using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task2Pershukevich.MainText;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainWriter
{
    public class Writer : IWriter, IDisposable
    {
        private bool disposed = false;


        private StreamWriter streamWriter;
        private string sourcePath { get; }

        public Writer(string path)
        {
            sourcePath = path;
        }
        
        public void Write(Text text)
        {
            try
            {
                using (streamWriter = new StreamWriter(sourcePath))
                {
                    foreach(Sentence sent in text.GetAllSentences())
                    {
                        streamWriter.WriteLine(sent.ToString());
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }


        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
