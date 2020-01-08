using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4BL.DTO;

namespace Task4Service
{
    public class CsvFileParser
    {
        public IEnumerable<ClientDTO> ParseClients(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var clients = csv.GetRecords<ClientDTO>();
                return clients;
            }
        }

        public ManagerDTO ParseManagers(string path)
        {
            string fileName = Path.GetFileName(path);
            string[] fileNameElements = fileName.Split('_');

            return new ManagerDTO() { Lastname = fileNameElements[0] };
        }

        public IEnumerable<ProductDTO> ParseProducts(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var products = csv.GetRecords<ProductDTO>();
                return products;
            }
        }

        public IEnumerable<OrderDTO> ParseOrders(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var orders = csv.GetRecords<OrderDTO>();
                return orders;
            }
        }
    }
}
