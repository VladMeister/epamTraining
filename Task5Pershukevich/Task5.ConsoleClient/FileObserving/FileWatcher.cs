using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.ConsoleClient.FileObserving
{
    public class FileWatcher : IFIleWatcher
    {
        public EventHandler<FileSystemEventArgs> FileChanged;
        FileSystemWatcher watcher;

        public void Run()
        {
            watcher = new FileSystemWatcher();

            watcher.Path = ConfigurationManager.AppSettings["directoryPath"];

            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            watcher.Filter = "*.csv";

            watcher.Created += OnChanged;

            // Begin watching
            watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            watcher.Created -= OnChanged;

            // Stop watching
            watcher.EnableRaisingEvents = false;

            watcher.Dispose();
        }

        private void OnChanged(object sender, FileSystemEventArgs args)
        {
            FileChanged?.Invoke(this, args);
        }
    }
}
