using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4BL.Exceptions
{
    public class ObjectNotExistingException : Exception
    {
        public ObjectNotExistingException() : base("This object does not exist!")
        {

        }
    }
}
