using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public enum TomatoType
    {
        Plum,
        Yellow,
        Cherry
    }

    public class Tomato : Vegetable
    {
        public TomatoType TomatoType { get; private set; }

        public Tomato(string name, double weight, double callories, TomatoType tomatotype) : base(name, weight, callories)
        {
            TomatoType = tomatotype;
        }
    }
}
