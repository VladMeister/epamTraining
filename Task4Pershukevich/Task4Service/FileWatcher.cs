using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task4Service
{
    public class FileWatcher
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

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;

                // Begin watching
                watcher.EnableRaisingEvents = true;
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
