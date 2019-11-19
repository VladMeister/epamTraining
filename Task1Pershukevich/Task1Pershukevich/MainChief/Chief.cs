using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Builders;

namespace Task1Pershukevich.MainChief
{
    public class Chief : IChief
    {
        public Salad MakeVitaminSalad(VitaminSaladBuilder builder) 
        {
            builder.AddCabbage();
            builder.AddCarrot();
            builder.AddOnion();
            builder.AddPepper();
            builder.AddSalt();
            builder.AddSugar();

            Console.WriteLine($"Salad '{builder.Salad.Name}' is ready!");

            return builder.Salad;
        }

        public Salad MakeMonomakhSalad(MonomakhSaladBuilder builder)
        {
            builder.AddCabbage();
            builder.AddCucumber();
            builder.AddOil();
            builder.AddPepper();
            builder.AddSalt();

            Console.WriteLine($"Salad {builder.Salad.Name} is ready!");

            return builder.Salad;
        }
    }
}
