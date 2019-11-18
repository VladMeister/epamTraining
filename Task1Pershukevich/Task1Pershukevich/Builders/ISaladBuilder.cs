using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.Builders
{
    interface ISaladBuilder
    {
       void AddIngridientToSalad(Ingridient ingridient);
    }
}
