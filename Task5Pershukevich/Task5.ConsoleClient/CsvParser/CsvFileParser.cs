using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.BL.DTO;
using Task5.ConsoleClient.SalesInfoParser;

namespace Task5.ConsoleClient.CsvParser
{
    public class CsvFileParser : ICsvParser
    {
        private IList<SalesInfo> salesInfo;

        public CsvFileParser()
        {
            salesInfo = new List<SalesInfo>();
        }

        public IEnumerable<SalesInfo> GetSalesInfoFromFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
            {
                var records = csv.GetRecords<SalesInfo>();
                salesInfo = records.ToList();
                return salesInfo;
            }
        }

        public ManagerDTO GetManagerFromFileByFileName(string fileName)
        {
            string[] fileNameElements = fileName.Split('_');

            return new ManagerDTO() { Lastname = fileNameElements[0] };
        }
    }
}
