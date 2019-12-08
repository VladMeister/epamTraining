using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.BS.BillingSystemElements
{
    public class Client
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
