using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients
{
    public abstract class Ingridient
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        private double CalloriesFor100gr { get; set; }

        public Ingridient(string name, double weight, double callories)
        {
            Name = name;
            Weight = weight;
            CalloriesFor100gr = callories;
        }

        public virtual double GetCallories() //полиморфизм
        {
            return CalloriesFor100gr;
        }
    }
}
