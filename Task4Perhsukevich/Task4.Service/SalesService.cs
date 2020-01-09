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
using Task4.Service.CsvParser;
using Task4.Service.FileObserving;

namespace Task4.Service
{
    public partial class SalesService : ServiceBase
    {
        private FileWatcher _fileWatcher;

        private string connectionString = "data source=(localdb);Initial Catalog=Sales;Integrated Security=True;";

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

        public void OnDebug()
        {
            OnStart(null);
        }

        public void HandleFileChanges(object sender, FileSystemEventArgs args)
        {
            CsvFileParser _csvFileParser = new CsvFileParser();

            //task run here

            //ProductService productService = new ProductService(connectionString);
            //ManagerService managerService = new ManagerService(connectionString);
            //ClientService clientService = new ClientService(connectionString);
            //OrderService orderService = new OrderService(connectionString);

            //object locker = new object();

            //lock (locker)
            //{
            //    _csvFileParser.ParseClients(args.FullPath).ToList().ForEach(x => clientService.AddClient(x));
            //    managerService.AddManager(_csvFileParser.ParseManager(args.Name));
            //    _csvFileParser.ParseProducts(args.FullPath).ToList().ForEach(x => productService.AddProduct(x));
            //    _csvFileParser.ParseOrders(args.FullPath).ToList().ForEach(x => orderService.AddOrder(x));
            //}

            _csvFileParser.GetSalesInfoFromFile(args.FullPath);
            //sc.exe delete ServiceName
        }
    }
}
