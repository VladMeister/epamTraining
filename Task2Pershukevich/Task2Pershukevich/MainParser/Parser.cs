﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText;
using System.IO;

namespace Task2Pershukevich.MainParser
{
    public abstract class Parser : IParser
    {
        public abstract Text ParseText();
    }
}
