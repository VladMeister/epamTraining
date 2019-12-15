using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Task3Pershukevich.ATS;
using Task3Pershukevich.billingSystem;

namespace Task3Pershukevich
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingSystem billingSystem = new BillingSystem();

            AutomaticStation automaticStation = new AutomaticStation(billingSystem);

            Client client = new Client("Dmitry", "Sapkov", "sapkov@gmail.com");
            Client client2 = new Client("Vadim", "Popov", "vadpop@mail.ru");

            Tariff tariff = new Tariff(TariffType.Standart);

            Contract contract = automaticStation.CreateNewContract(client, tariff, "702391");
            Contract contract2 = automaticStation.CreateNewContract(client2, tariff, "765946");

            Terminal terminal = automaticStation.AddNewTerminal(contract, contract.NewNumber);
            Terminal terminal2 = automaticStation.AddNewTerminal(contract2, contract2.NewNumber);

            Port port = new Port(0001);
            Port port2 = new Port(0002);

            automaticStation.AddNewPort(terminal, port);
            automaticStation.AddNewPort(terminal2, port2);

            port.PlugInTerminal();
            port2.PlugInTerminal();

            try
            {
                terminal.TryToConnect("765946");
            }
            catch
            {
                Console.WriteLine("Incorrect call input!");
            }

            Thread.Sleep(5000);
            terminal.CallEnd("765946");

            //terminal.CallAnswer("765946");
            //Thread.Sleep(5000);
            //terminal.CallEnd("765946");



            Console.WriteLine("Get every element from calldata list: ");
            foreach (CallInfo callInfo in billingSystem.GetAllElements())
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get length of every call from calldata list: ");
            foreach (int length in billingSystem.GetLengthOfEveryCall())
            {
                Console.WriteLine(length);
            }
            Console.WriteLine();

            Console.WriteLine("Get cost of every call from calldata list: ");
            foreach (int cost in billingSystem.GetCostOfEveryCall())
            {
                Console.WriteLine(cost);
            }
            Console.WriteLine();

            Console.WriteLine("Get every number from calldata list: ");
            foreach (string number in billingSystem.GetDestinationNumberOfEveryCall())
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by date of call calldata list: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByDateOfCall())
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by destination number calldata list: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByDestinationNumber())
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by price of call calldata list: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByPrice())
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
