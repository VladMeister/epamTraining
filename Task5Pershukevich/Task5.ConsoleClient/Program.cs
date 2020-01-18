using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.ConsoleClient.FileObserving;
using Task5.ConsoleClient.SalesInfoParser;

namespace Task5.ConsoleClient
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        static void Main(string[] args)
        {
            FileWatcher fileWatcher = new FileWatcher();
            RunWatcher(fileWatcher);

            Console.Read();
            //StopWatcher(fileWatcher);
        }

        static void RunWatcher(FileWatcher fileWatcher)
        {
            fileWatcher.FileChanged += HandleFileChanges;
            fileWatcher.Run();
        }

        static void StopWatcher(FileWatcher fileWatcher)
        {
            fileWatcher.Stop();
        }

        static void HandleFileChanges(object sender, FileSystemEventArgs args)
        {
            Task task = Task.Run(() =>
            {
                SalesFileParser salesFileParser = new SalesFileParser();

                salesFileParser.AddInfoToDataBase(connectionString, args.FullPath, args.Name);
            });
        }
    }
}
