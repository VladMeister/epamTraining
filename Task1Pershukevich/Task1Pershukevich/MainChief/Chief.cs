using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.MainSalad;

namespace Task1Pershukevich.MainChief
{
    public class Chief : IChief
    {
        private void AddIngridientToSalad(Ingridient ingridient)
        {
            Console.WriteLine($"Adding {ingridient.Name} to salad");
        }

        public void CheckEveryIngridient(Salad salad)
        {
            foreach(Ingridient i in salad.GetAllIngridients())
            {
                AddIngridientToSalad(i);
            }
            Console.WriteLine($"Salad {salad.Name} is ready!");
        }
    }
}
