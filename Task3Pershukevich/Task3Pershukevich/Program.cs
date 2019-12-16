using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Task3Pershukevich.Exceptions;
using Task3Pershukevich.ATS;
using Task3Pershukevich.BillSystem;

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

            Terminal terminal = automaticStation.GiveNewTerminal(contract, contract.PhoneNumber);
            Terminal terminal2 = automaticStation.GiveNewTerminal(contract2, contract2.PhoneNumber);

            Port port = new Port(0001);
            Port port2 = new Port(0002);

            automaticStation.AssignToTerminalNewPort(terminal, port);
            automaticStation.AssignToTerminalNewPort(terminal2, port2);

            terminal.PlugInPort();
            terminal2.PlugInPort();

            Console.WriteLine("Making call to number 765946...");
            try
            {
                terminal.MakeRing("765946");
            }
            catch(MakeCallException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(5000);
            try
            {
                terminal.EndCall("765946");
            }
            catch (EndCallException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Call ended.");


            Console.WriteLine("Answering a call from number 702391...");
            try
            {
                terminal2.AnswerCall("702391");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(3000);
            try
            {
                terminal2.EndCall("702391");
            }
            catch (EndCallException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Call ended." + '\n');



            Console.WriteLine("Get every calldata info: ");
            foreach (CallInfo callInfo in billingSystem.GetEveryCallInfo())
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get calls report: ");
            foreach (string callReport in billingSystem.GetCallsReport())
            {
                Console.WriteLine(callReport);
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by date of call calldata: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByDateOfCall(new DateTime(2019, 12, 16)))
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by destination number calldata: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByDestinationNumber("702391"))
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get filtered by call price calldata: ");
            foreach (CallInfo callInfo in billingSystem.GetFilteredCallsByPrice(10))
            {
                Console.WriteLine(callInfo.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Get minimal call price from calldata: ");
            Console.WriteLine(billingSystem.GetMinimalPriceOfCall());
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}
