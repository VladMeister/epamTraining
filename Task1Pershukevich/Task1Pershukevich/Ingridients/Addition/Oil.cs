using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.Ingridients.Addition
{
    public enum OilType
    {
        Olive,
        Vinegar,
        sunFlower
    }


    public class Oil : Spices
    {
        private OilType oilType { get; set; }

        public Oil(string name, OilType oiltype, double weight, double callories) : base(name, weight, callories)
        {

        }
    }
}
