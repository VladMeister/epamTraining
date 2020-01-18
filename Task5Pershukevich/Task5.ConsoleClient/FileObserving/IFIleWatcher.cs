using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.ConsoleClient.FileObserving
{
    public interface IFIleWatcher
    {
        void Run();
        void Stop();
    }
}
