using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public class Carrot : Vegetable
    {
        private bool isBoiled { get; set; }

        public Carrot(string name, double weight, double callories, bool isboiled) : base(name, weight, callories)
        {
            isBoiled = isboiled;
        }
    }
}
