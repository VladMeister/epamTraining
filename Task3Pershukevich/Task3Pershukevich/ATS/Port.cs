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
        public event EventHandler<PortCondition> ChangePortCondition;

        public PortCondition PortCondition { get; private set; }
        public int IdNumber { get; private set; }

        public Port()
        {
            PortCondition = PortCondition.Off;
        }

        public void ChangeCondition(PortCondition portCondition)
        {
            PortCondition = PortCondition;
            ChangePortCondition?.Invoke(this, PortCondition);
        }
    }
}
