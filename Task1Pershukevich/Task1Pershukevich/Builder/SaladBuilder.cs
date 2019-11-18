using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.Builder
{
    public abstract class SaladBuilder : ISaladBuilder
    {
        public Salad salad { get; set; }

        public void AddIngridientToSalad(Ingridient ingridient)
        {
            Console.WriteLine($"Adding {ingridient.Name} to salad '{salad.Name}'");
            salad.AddIngridient(ingridient);
        }
    }
}
