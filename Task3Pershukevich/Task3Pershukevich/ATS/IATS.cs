using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    interface IATS
    {
        Contract CreateNewContract(Client client, Tariff tariff, Port port, string phoneNumber, int terminalNumber);
        void SwitchPortState(PortCondition portCondition);
    }
}
