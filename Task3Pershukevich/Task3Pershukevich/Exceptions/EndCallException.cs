using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.Exceptions
{
    public class EndCallException : Exception
    {
        public EndCallException()
        {

        }

        public EndCallException(string message) : base(message)
        {

        }
    }
}
