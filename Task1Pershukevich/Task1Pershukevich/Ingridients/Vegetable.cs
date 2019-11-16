using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Interfaces;

namespace Task1Pershukevich.Ingridients
{
     public abstract class Vegetable : Ingridient
    {
        public Vegetable(string name, double weight, double callories) : base(name, weight, callories)
        {

        }

        public override double GetCallories()
        {
            return base.GetCallories() * 0.1 * Weight;
        }
    }
}
