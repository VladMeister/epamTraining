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
        private bool isFried { get; set; }
        private OnionType onionType { get; set; }

        public Onion(string name, double weight, double callories, bool isfried, OnionType oniontype) : base(name, weight, callories)
        {
            isFried = isfried;
            onionType = oniontype;
        }
    }
}
