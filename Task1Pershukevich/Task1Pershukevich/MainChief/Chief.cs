using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Builder;

namespace Task1Pershukevich.MainChief
{
    public class Chief : IChief
    {
        private void AddIngridientToSalad(Ingridient ingridient) 
        {
            Console.WriteLine($"Adding {ingridient.Name} to salad");
        }

        public Salad MakeSalad(SaladBuilder builder) 
        {
            foreach (Ingridient i in builder.salad.GetAllIngridients())
            {
                AddIngridientToSalad(i);
            }

            Console.WriteLine($"Salad {builder.salad.Name} is ready!");

            return builder.salad;
        }
    }
}
