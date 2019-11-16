﻿using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.Interfaces
{
    interface IVegetablesFilter
    {
        IEnumerable<Vegetable> GetVegetablesByCallories(double minCal, double maxCal);
    }
}
