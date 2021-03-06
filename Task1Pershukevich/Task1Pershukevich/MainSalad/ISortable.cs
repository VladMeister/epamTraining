﻿using System;
using System.Collections.Generic;
using System.Text;
using Task1Pershukevich.Ingridients;

namespace Task1Pershukevich.MainSalad
{
    interface ISortable
    {
        IEnumerable<Vegetable> SortVegetablesByCallories();
        IEnumerable<Vegetable> SortVegetablesByName();
        IEnumerable<Vegetable> SortVegetablesByWeight();
    }
}
