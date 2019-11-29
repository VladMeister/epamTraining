using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Pershukevich.MainWriter
{
    public class Writer : IWriter, IDisposable
    {
        private bool disposed = false;








        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //if (SR != null)
                    //{
                    //    SR.Dispose();
                    //}
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
