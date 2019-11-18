using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.Builders
{
    public abstract class SaladBuilder : ISaladBuilder
    {
        public Salad salad { get; set; }

        public void AddIngridientToSalad(Ingridient ingridient)
        {
            Console.WriteLine($"Adding {ingridient.Name} to salad '{salad.Name}'");
            salad.AddIngridient(ingridient);
        }

        public void Create(string name)
        {
            List<Ingridient> ingridients = new List<Ingridient>();

            salad = new Salad(name, ingridients);
        }
    }
}
