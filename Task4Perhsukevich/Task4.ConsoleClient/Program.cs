using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using Task4.Service;

namespace Task4.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SalesService()
            };

            ServiceBase.Run(ServicesToRun);

            Console.Read();
        }
    }
}
