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
        public int ChargePerMinute { get; private set; }
        public TariffType TariffType { get; private set; }

        public Tariff(TariffType type)
        {
            SetTariffData(type);
        }

        private void SetTariffData(TariffType type)
        {
            TariffType = type;

            if(type == TariffType.Standart)
            {
                ChargePerMinute = 20;
            }

            else
            {
                ChargePerMinute = 0;
            }
        }

    }
}
