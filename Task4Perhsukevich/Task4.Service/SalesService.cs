using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.Services;
using Task4.Service.CsvParser;
using Task4.Service.FileObserving;
using Task4.Service.SalesInfoParser;

namespace Task4.Service
{
    public partial class SalesService : ServiceBase
    {
        private FileWatcher _fileWatcher;

        //private string connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;
        private string connectionString = "data source = (localdb); Initial Catalog = Sales; Integrated Security = True;";

        public SalesService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _fileWatcher = new FileWatcher();
            _fileWatcher.FileChanged += HandleFileChanges;
            _fileWatcher.Run();
        }

        protected override void OnStop()
        {
            _fileWatcher.Stop();
            _fileWatcher.FileChanged -= HandleFileChanges;
        }

        public void HandleFileChanges(object sender, FileSystemEventArgs args)
        {
            Task task = Task.Run( () =>
            {
                SalesFileParser.AddInfoToDataBase(connectionString, args.FullPath, args.Name);
            });
        }
    }
}
