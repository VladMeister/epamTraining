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
        public void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = ConfigurationManager.AppSettings["directoryPath"];

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                watcher.Filter = "*.csv";

                // Add event handlers.
                watcher.Changed += OnChanged;
                //watcher.Created += OnChanged;
                //watcher.Deleted += OnChanged;
                //watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
