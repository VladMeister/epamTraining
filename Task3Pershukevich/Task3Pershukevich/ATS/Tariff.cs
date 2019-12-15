using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public enum TariffType
    {
        Standart
    }

    public class Tariff
    {
        public static int ChargePerMinute = 20;
        public TariffType TariffType { get; private set; }

        public Tariff(TariffType type)
        {
            TariffType = type;
        }

    }
}
