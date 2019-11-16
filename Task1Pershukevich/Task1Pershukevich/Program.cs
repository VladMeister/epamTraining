using System;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.Ingridients.Vegetables;
using Task1Pershukevich.Ingridients.Spices;
using Task1Pershukevich.MainChief;
using Task1Pershukevich.MainSalad;
using System.Collections.Generic;

namespace Task1Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            Chief chief = new Chief();

            List<Ingridient> ingridients = new List<Ingridient>();

            Salad salad = new Salad("TestName", ingridients);    //create

            salad.AddIngridient(new Cabbage("Cabbage", 35.2, 25, CabbageType.Red));   //fill    
            salad.AddIngridient(new Potato("Potato", 57.8, 23.2));                    //callories value for 100g of product
            salad.AddIngridient(new Tomato("Tomato", 21, 35.5, TomatoType.Cherry));
            salad.AddIngridient(new Cucumber("Cucumber", 31, 11.3, CucumberType.Persian));
            salad.AddIngridient(new Oil("Oil", OilType.Olive, 20));
            salad.AddIngridient(new Salt("Salt", 3.2));


            chief.CheckEveryIngridient(salad);    //Creating salad

  
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
