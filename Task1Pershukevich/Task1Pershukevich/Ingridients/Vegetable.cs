using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
     public abstract class Vegetable : Ingridient
    {
        private double numberOfCallories { get; set; }

        public Vegetable(string name, double weight, double callories) : base(name, weight)
        {
            numberOfCallories = callories;
        }

        public override double GetCallories()
        {
            return numberOfCallories * 0.1 * Weight;
        }
    }
}
