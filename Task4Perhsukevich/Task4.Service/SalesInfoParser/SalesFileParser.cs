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
        public void AddInfoToDataBase(string connectionString, string filePath, string fileName)
        {
            int clientId;
            int productId;
            int managerId;

            ProductService productService = new ProductService(connectionString);
            ManagerService managerService = new ManagerService(connectionString);
            ClientService clientService = new ClientService(connectionString);
            OrderService orderService = new OrderService(connectionString);

            CsvFileParser csvFileParser = new CsvFileParser();

            ManagerDTO managerDTO = new ManagerDTO() { Lastname = csvFileParser.GetManagerFromFileByFileName(fileName).Lastname };

            if(CheckForExistingManager(managerService, managerDTO.Lastname))
            {
                managerId = managerDTO.Id;
            }
            else
            {
                managerId = managerService.AddManager(managerDTO);
            }

            try
            {
                foreach (SalesInfo salesInfo in csvFileParser.GetSalesInfoFromFile(filePath))
                {
                    string[] firstLastName = salesInfo.Client.Split(' ');

                    ProductDTO productDTO = new ProductDTO() { Name = salesInfo.Product };
                    ClientDTO clientDTO = new ClientDTO() { Firstname = firstLastName[0], Lastname = firstLastName[1] };

                    if (CheckForExistingProduct(productService, productDTO.Name))
                    {
                        productId = productDTO.Id;
                    }
                    else
                    {
                        productId = productService.AddProduct(productDTO);
                    }

                    if (CheckForExistingClient(clientService, clientDTO.Firstname, clientDTO.Lastname))
                    {
                        clientId = clientDTO.Id;
                    }
                    else
                    {
                        clientId = clientService.AddClient(clientDTO);
                    }

                    OrderDTO orderDTO = new OrderDTO() { Date = salesInfo.Date, Cost = salesInfo.Cost, ClientId = clientId, ManagerId = managerId, ProductId = productId };
                    orderService.AddOrder(orderDTO);
                }
            }
            catch(CsvHelperException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool CheckForExistingProduct(ProductService productService, string product)
        {
            return productService.GetAll().Any(p => p.Name == product);
        }

        private bool CheckForExistingClient(ClientService clientService, string clientFirstName, string clientLastName)
        {
            return clientService.GetAll().Any(c => c.Firstname == clientFirstName && c.Lastname == clientLastName);
        }

        private bool CheckForExistingManager(ManagerService managerService, string managerLastName)
        {
            return managerService.GetAll().Any(m => m.Lastname == managerLastName);
        }
    }
}
