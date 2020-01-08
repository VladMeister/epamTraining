using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Task4BL.Services;

namespace Task4Service
{
    public partial class SalesService : ServiceBase
    {
        private FileWatcher _fileWatcher;
        private CsvFileParser _csvFileParser;

        private string connectionString = "data source=(localdb);Initial Catalog=Sales;Integrated Security=True;";

        public SalesService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _fileWatcher = new FileWatcher();
            _fileWatcher.FileChanged += HandleFiles;
            _fileWatcher.Run();

            ProductService productService = new ProductService(connectionString);
            ManagerService managerService = new ManagerService(connectionString);
            ClientService clientService = new ClientService(connectionString);
            OrderService orderService = new OrderService(connectionString);
        }

        protected override void OnStop()
        {
            _fileWatcher.Stop();
            _fileWatcher.FileChanged -= HandleFiles;
        }

        public void HandleFiles(object sender, FileSystemEventArgs args)
        {
            //_csvFileParser.ParseClients(args.FullPath);
            //_csvFileParser.ParseManagers(args.FullPath);
            //_csvFileParser.ParseProducts(args.FullPath);
            //_csvFileParser.ParseOrders(args.FullPath);
        }
    }
}
