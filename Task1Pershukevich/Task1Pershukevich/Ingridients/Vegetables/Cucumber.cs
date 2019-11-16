using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Pershukevich.Ingridients.Vegetables
{
    public enum CucumberType
    {
        Persian,
        Long,
        English
    }

    public class Cucumber : Vegetable
    {
        public CucumberType CucumberType { get; private set; }

        public Cucumber(string name, double weight, double callories, CucumberType cucumbertype) : base(name, weight, callories)
        {
            CucumberType = cucumbertype;
        }
    }
}
