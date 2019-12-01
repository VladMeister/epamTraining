using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;

namespace Task2Pershukevich.MainWriter
{
    public interface IWriter
    {
        void Write(Text text);
    }
}
