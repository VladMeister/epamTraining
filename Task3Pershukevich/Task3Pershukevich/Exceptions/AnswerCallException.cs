using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.Exceptions
{
    public class AnswerCallException : Exception
    {
        public AnswerCallException()
        {

        }

        public AnswerCallException(string message) : base(message)
        {

        }
    }
}
