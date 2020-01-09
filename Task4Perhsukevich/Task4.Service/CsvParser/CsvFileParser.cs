using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.DTO;
using Task4.Service.SalesInfoParser;

namespace Task4.Service.CsvParser
{
    public class CsvFileParser : ICsvParser
    {
        public IEnumerable<SalesInfo> GetSalesInfoFromFile(string path)
        {
            IEnumerable<SalesInfo> salesInfo;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<SalesInfo>();
                salesInfo = records;
            }

            return salesInfo;
        }

        public ManagerDTO GetManagerFromFileByFileName(string fileName)
        {
            string[] fileNameElements = fileName.Split('_');

            return new ManagerDTO() { Lastname = fileNameElements[0] };
        }
    }
}
