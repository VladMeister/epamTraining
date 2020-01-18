using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
using Task5.ConsoleClient.SalesInfoParser;

namespace Task5.ConsoleClient.CsvParser
{
    public interface ICsvParser
    {
        IEnumerable<SalesInfo> GetSalesInfoFromFile(string path);
        ManagerDTO GetManagerFromFileByFileName(string fileName);
    }
}
