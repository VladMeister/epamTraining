﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BL.Services
{
    public interface ISalesService<T>
    {
        void Dispose();
        IEnumerable<T> GetAll();
    }
}
