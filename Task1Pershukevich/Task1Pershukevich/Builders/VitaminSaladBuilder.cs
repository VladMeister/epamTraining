using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients.Vegetables;
using Task1Pershukevich.Ingridients.Spices;

namespace Task1Pershukevich.Builders
{
    public class VitaminSaladBuilder : SaladBuilder
    {
        public void AddCabbage()
        {
            AddIngridientToSalad(new Cabbage("Cabbage", 35.2, 25, CabbageType.Red));
        }

        public void AddPepper()
        {
            AddIngridientToSalad(new Pepper("Pepper", 11.5, 15, PepperType.Yellow));
        }

        public void AddOnion()
        {
            AddIngridientToSalad(new Onion("Onion", 13.7, 10.5, OnionType.Sweet));
        }

        public void AddCarrot()
        {
            AddIngridientToSalad(new Carrot("Carrot", 26.1, 9.1));
        }

        public void AddSalt()
        {
            AddIngridientToSalad(new Salt("Salt", 3.5));
        }

        public void AddSugar()
        {
            AddIngridientToSalad(new Sugar("Sugar", 2, SugarType.Cane));
        }
    }
}
