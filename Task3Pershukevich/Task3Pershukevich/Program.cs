using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.ATS;
using Task3Pershukevich.billingSystem;

namespace Task3Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomaticStation automaticStation = new AutomaticStation();

            Client client = new Client("Dmitry", "Sapkov", "sapkov@gmail.com");
            Tariff tariff = new Tariff(TariffType.Standart);

            Contract contract = automaticStation.CreateNewContract(client, tariff, "702391");

            Terminal terminal = automaticStation.AddNewTerminal(contract, contract.NewNumber);

            Port port = new Port(0001);
   
            automaticStation.AddNewPort(terminal, port);



            Console.ReadKey();
        }
    }
}
