using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients.Vegetables;
using Task1Pershukevich.Ingridients.Spices;

namespace Task1Pershukevich.Builder
{
    public class MonomakhSaladBuilder : SaladBuilder
    {
        public void AddCabbage()
        {
            AddIngridientToSalad(new Cabbage("Cabbage", 25.1, 23, CabbageType.Savoy));
        }

        public void AddCucumber()
        {
            AddIngridientToSalad(new Cucumber("Cucumber", 31, 11.3, CucumberType.Persian));
        }

        public void AddPepper()
        {
            AddIngridientToSalad(new Pepper("Pepper", 3.7, 15.5, PepperType.Yellow));
        }

        public void AddOil()
        {
            AddIngridientToSalad(new Oil("Oil", OilType.Olive, 20));
        }

        public void AddSalt()
        {
            AddIngridientToSalad(new Salt("Salt", 1.7));
        }
    }
}
