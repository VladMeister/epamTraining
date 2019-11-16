using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
    public abstract class Spice : Ingridient
    {
       public Spice(string name, double weight, double callories) : base(name, weight, callories)
        {

        }

        public override double GetCallories()
        {
            return base.GetCallories()*0;
        }
    }
}
