using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public enum PepperType
    {
        Red,
        Yellow,
        Green
    }

    public class Pepper : Vegetable
    {
        public PepperType PepperType { get; private set; }

        public Pepper(string name, double weight, double callories, PepperType peppertype) : base(name, weight, callories)
        {
            PepperType = peppertype;
        }
    }
}
