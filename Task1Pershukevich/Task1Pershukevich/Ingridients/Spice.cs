using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
    public abstract class Spice : Ingridient
    {
       public Spice(string name, double weight) : base(name, weight)
        {

        }

        public override double GetCallories()
        {
            return 0;
        }
    }
}
