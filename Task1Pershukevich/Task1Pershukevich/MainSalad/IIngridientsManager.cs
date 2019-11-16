using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.MainSalad
{
    interface IIngridientsManager
    {
        IEnumerable<Ingridient> GetAllIngridients();
        void AddIngridient(Ingridient ingridient);
        void RemoveAllIngridients(); //clear
    }
}
