using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Addition
{
    public enum SugarType
    {
        Granulated,
        Pearl,
        Cane,
        Brown
    }

    public class Sugar : Spices
    {
        private SugarType sugarType { get; set; }

        public Sugar(string name, double weight, double callories, SugarType sugartype) : base(name, weight, callories)
        {
            sugarType = sugartype;
        }
    }
}
