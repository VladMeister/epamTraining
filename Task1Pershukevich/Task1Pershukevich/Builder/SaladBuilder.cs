using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.MainSalad;

namespace Task1Pershukevich.Builder
{
    public class SaladBuilder : ISaladBuilder
    {
        public Salad salad { get; private set; }
    }
}
