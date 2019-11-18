using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.MainSalad;
using Task1Pershukevich.Builder;

namespace Task1Pershukevich.MainChief
{
    interface IChief
    {
        Salad MakeVitaminSalad(VitaminSaladBuilder builder);
        Salad MakeMonomakhSalad(MonomakhSaladBuilder builder);
    }
}
