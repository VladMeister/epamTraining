using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public class Cucumber : Vegetable
    {
        //private bool isPickled { get; set; }

        public Cucumber(string name, double weight, double callories, bool ispickled) : base(name, weight, callories)
        {
            isPickled = ispickled;
        }
    }
}
