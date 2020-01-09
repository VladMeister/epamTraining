using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.DTO;
using Task4.BL.Services;
using Task4.Service.CsvParser;
using CsvHelper;

namespace Task4.Service.SalesInfoParser
{
    public class SalesFileParser
    {
        public static void AddInfoToDataBase(string connectionString, string filePath, string fileName)
        {
            ProductService productService = new ProductService(connectionString);
            ManagerService managerService = new ManagerService(connectionString);
            ClientService clientService = new ClientService(connectionString);
            OrderService orderService = new OrderService(connectionString);

            CsvFileParser csvFileParser = new CsvFileParser();

            try
            {
                foreach (SalesInfo salesInfo in csvFileParser.GetSalesInfoFromFile(filePath).ToList())
                {
                    string[] firstLastName = salesInfo.Client.Split(' ');

                    ManagerDTO managerDTO = new ManagerDTO() { Lastname = csvFileParser.GetManagerFromFileByFileName(fileName).Lastname };
                    ProductDTO productDTO = new ProductDTO() { Name = salesInfo.Product };
                    ClientDTO clientDTO = new ClientDTO() { Firstname = firstLastName[0], Lastname = firstLastName[1] };
                    OrderDTO orderDTO = new OrderDTO() { Date = salesInfo.Date, Cost = salesInfo.Cost, ClientId = clientDTO.Id, ManagerId = managerDTO.Id, ProductId = productDTO.Id };

                    productService.AddProduct(productDTO);
                    managerService.AddManager(managerDTO);
                    clientService.AddClient(clientDTO);
                    orderService.AddOrder(orderDTO);
                }
            }
            catch(CsvHelperException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
