using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public enum PortCondition
    {
        Free,
        Off,
        Busy
    }

    public class Port
    {
        public PortCondition PortCondition { get; private set; }

    }
}
