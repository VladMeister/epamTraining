using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BL.Exceptions
{
    public class ObjectNotExistingException : Exception
    {
        public ObjectNotExistingException(string message) : base(message)
        {

        }
    }
}
