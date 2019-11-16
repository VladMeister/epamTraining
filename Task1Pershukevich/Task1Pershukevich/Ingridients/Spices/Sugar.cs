using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Spices
{
    public enum SugarType
    {
        Granulated,
        Pearl,
        Cane,
        Brown
    }

    public class Sugar : Spice
    {
        public SugarType SugarType { get; private set; }

        public Sugar(string name, double weight, SugarType sugartype) : base(name, weight)
        {
            SugarType = sugartype;
        }
    }
}
