using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Interfaces;
using Task1Pershukevich.Ingridients;
using System.Linq;

namespace Task1Pershukevich
{
    public class Salad : IIngridientManage, IFilterVegetables, ISortable
    {
        private IList<Ingridient> Ingridients { get; set; }
        public string Name { get; private set; }

        public Salad(string name, IList<Ingridient> ingridients)
        {
            Name = name;
            Ingridients = ingridients;
        }

        public void AddIngridient(Ingridient ingridient)
        {
            Ingridients.Add(ingridient);
        }

        public void RemoveAllIngridients()
        {
            Ingridients.Clear();
        }

        public double CountAllCallories()
        {
            double allCallories = 0;

            foreach(Ingridient i in Ingridients)
            {
                allCallories += i.GetCallories();
            }

            return allCallories;
        }

        public IEnumerable<Ingridient> GetAllIngridients()
        {
            return Ingridients;
        }

        private IEnumerable<Vegetable> GetVegetables()
        {
            IList<Vegetable> vegetables = new List<Vegetable>();

            foreach (Ingridient i in Ingridients)
            {
                if (i is Vegetable)
                {
                    vegetables.Add((Vegetable)i);
                }
            }

            return vegetables;
        }

        public IEnumerable<Vegetable> GetVegetablesByCallories(double minCal, double maxCal)
        {
            var vegetables = GetVegetables().Where(i => i.GetCallories() >= minCal && i.GetCallories() <= maxCal);

            return vegetables;
        }

        public IEnumerable<Vegetable> SortVegetablesByCallories()
        {
            var vegetables = GetVegetables().OrderBy(v => v.GetCallories());

            return vegetables;
        }

        public IEnumerable<Vegetable> SortVegetablesByName()
        {
            var vegetables = GetVegetables().OrderBy(v => v.Name);

            return vegetables;
        }

        public IEnumerable<Vegetable> SortVegetablesByWeight() 
        {
            var vegetables = GetVegetables().OrderBy(v => v.Weight);

            return vegetables;
        }
    }
}
