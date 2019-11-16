using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
    public abstract class Spices : Ingridient
    {
       public Spices(string name, double weight, double callories) : base(name, weight, callories)
        {

        }

        public override double GetCallories()
        {
            return base.GetCallories()*0;
        }
    }
}
