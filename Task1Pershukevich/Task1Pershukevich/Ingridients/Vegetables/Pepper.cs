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
        private PepperType pepperType { get; set; }

        public Pepper(string name, double weight, double callories, PepperType peppertype) : base(name, weight, callories)
        {
            pepperType = peppertype;
        }
    }
}
