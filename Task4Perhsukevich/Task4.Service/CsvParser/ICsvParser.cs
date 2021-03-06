﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.DTO;
using Task4.Service.SalesInfoParser;

namespace Task4.Service.CsvParser
{
    public interface ICsvParser
    {
        IEnumerable<SalesInfo> GetSalesInfoFromFile(string path);
        ManagerDTO GetManagerFromFileByFileName(string fileName);
    }
}
