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
        public int CostPerMonth { get; private set; }
        public int LimitedMinutesPerMonth { get; private set; }
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
                CostPerMonth = 10;
                LimitedMinutesPerMonth = 120;
            }

            else
            {
                CostPerMonth = 0;
                LimitedMinutesPerMonth = 0;
            }
        }

    }
}
