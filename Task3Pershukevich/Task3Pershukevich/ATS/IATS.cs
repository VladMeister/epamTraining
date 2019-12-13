using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public interface IATS
    {
        Contract CreateNewContract(Client client, Tariff tariff, Port port, string phoneNumber, int terminalNumber);
        void SwitchPortState(object sender, PortCondition portCondition);
    }
}
