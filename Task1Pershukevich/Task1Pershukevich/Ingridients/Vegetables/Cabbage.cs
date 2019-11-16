using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public enum CabbageType
    {
        Savoy,
        Red,
        Pekin
    }

    public class Cabbage : Vegetable
    {
        public CabbageType CabbageType { get; private set; }

        public Cabbage(string name, double weight, double callories, CabbageType cabbagetype) : base(name, weight, callories)
        {
            CabbageType = cabbagetype;
        }
    }
}
