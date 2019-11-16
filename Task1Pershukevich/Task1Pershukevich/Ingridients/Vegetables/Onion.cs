using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public enum OnionType
    {
        Yellow,
        Red,
        Sweet,
        White
    }

    public class Onion : Vegetable
    {
        public OnionType OnionType { get; private set; }

        public Onion(string name, double weight, double callories, OnionType oniontype) : base(name, weight, callories)
        {
            OnionType = oniontype;
        }
    }
}
