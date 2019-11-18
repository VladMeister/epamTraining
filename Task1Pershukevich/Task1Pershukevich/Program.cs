using System;
using Task1Pershukevich.Ingridients;
using Task1Pershukevich.Ingridients.Vegetables;
using Task1Pershukevich.Ingridients.Spices;
using Task1Pershukevich.MainChief;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Builders;
using System.Collections.Generic;

namespace Task1Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            Chief chief = new Chief();

            VitaminSaladBuilder vitaminSaladBuilder = new VitaminSaladBuilder();

            vitaminSaladBuilder.Create("Vitamin Salad");  //create builder

            Salad salad = chief.MakeVitaminSalad(vitaminSaladBuilder);    //Creating salad

  
            Console.WriteLine($"\nAll callories counted in salad: {salad.CountAllCallories()}");    //count callority of salad


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
