using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
    public abstract class Ingridient
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }

        public Ingridient(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract double GetCallories(); //abstraction
    }
}
