using System;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.Ingridients.Vegetables;
using Task1Pershukevich.Ingridients.Spices;
using Task1Pershukevich.MainChief;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Builder;
using System.Collections.Generic;

namespace Task1Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            Chief chief = new Chief();

            List<Ingridient> ingridients = new List<Ingridient>();

            SaladBuilder saladBuilder = new SaladBuilder();

            saladBuilder.salad  = new Salad("TestName", ingridients);   //create builder

            saladBuilder.salad.AddIngridient(new Cabbage("Cabbage", 35.2, 25, CabbageType.Red));   //fill    
            saladBuilder.salad.AddIngridient(new Potato("Potato", 57.8, 23.2));                    //callories value for 100g of product
            saladBuilder.salad.AddIngridient(new Tomato("Tomato", 21, 35.5, TomatoType.Cherry));
            saladBuilder.salad.AddIngridient(new Cucumber("Cucumber", 31, 11.3, CucumberType.Persian));
            saladBuilder.salad.AddIngridient(new Oil("Oil", OilType.Olive, 20));
            saladBuilder.salad.AddIngridient(new Salt("Salt", 3.5));


            Salad salad = chief.MakeSalad(saladBuilder);    //Creating salad

  
            Console.WriteLine($"\nCounted all callories in salad: {salad.CountAllCallories()}");    //count callority of salad


            Console.WriteLine('\n' + "Sorted by weight vegetables: ");

            foreach (Vegetable v in salad.SortVegetablesByWeight())   //sort by weight
            {
                Console.WriteLine($"{v.Name} - {v.Weight}");
            }

            Console.WriteLine('\n' + "Vegetables in callories range: ");

            foreach (Vegetable v in salad.GetVegetablesByCallories(5, 36))    //search by callories
            {
                Console.WriteLine(v.Name);
            }

            Console.ReadKey();
        }
    }
}
