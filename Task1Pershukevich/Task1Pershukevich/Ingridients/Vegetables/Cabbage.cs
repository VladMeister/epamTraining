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
        private CabbageType cabbageType { get; set; }

        public Cabbage(string name, double weight, double callories, CabbageType cabbagetype) : base(name, weight, callories)
        {
            cabbageType = cabbagetype;
        }
    }
}
