using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using Task4.Service;
using System.IO;
using Task4.Service.SalesInfoParser;
using Task4.Service.FileObserving;

namespace Task4.ConsoleClient
{
    class Program
    {
        static string connectionString = "data source = (localdb); Initial Catalog = Sales; Integrated Security = True;";

        static void Main(string[] args)
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new SalesService()
            //};

            //ServiceBase.Run(ServicesToRun);

            RunWatcher();

            Console.Read();
        }

        static void RunWatcher()
        {
            FileWatcher fileWatcher = new FileWatcher();
            fileWatcher.FileChanged += HandleFileChanges;
            fileWatcher.Run();
        }

        static void HandleFileChanges(object sender, FileSystemEventArgs args)
        {
            Task task = Task.Run(() =>
            {
                SalesFileParser.AddInfoToDataBase(connectionString, args.FullPath, args.Name);
            });
        }
    }
}
