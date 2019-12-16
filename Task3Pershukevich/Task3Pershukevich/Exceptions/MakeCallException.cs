using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.Exceptions
{
    public class MakeCallException : Exception
    {
        public MakeCallException()
        {

        }

        public MakeCallException(string message) : base (message)
        {

        }
    }
}
