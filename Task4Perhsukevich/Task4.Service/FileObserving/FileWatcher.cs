using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Service.FileObserving
{
    public class FileWatcher : IFileWatcher
    {
        public EventHandler<FileSystemEventArgs> FileChanged;

        public void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = ConfigurationManager.AppSettings["directoryPath"];

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.csv";

                //watcher.Changed += OnChanged;
                watcher.Created += OnChanged;

                // Begin watching
                watcher.EnableRaisingEvents = true;

                while (true) ;
            }
        }

        public void Stop()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Changed -= OnChanged;
                watcher.Created -= OnChanged;

                // Stop watching
                watcher.EnableRaisingEvents = false;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs args)
        {
            FileChanged?.Invoke(this, args);
        }
    }
}
