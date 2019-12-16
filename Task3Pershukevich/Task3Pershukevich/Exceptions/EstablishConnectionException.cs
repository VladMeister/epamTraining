using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.Exceptions
{
    public class EstablishConnectionException : Exception
    {
        public EstablishConnectionException()
        {

        }

        public EstablishConnectionException(string message) : base(message)
        {

        }
    }
}
