using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Pershukevich.ATS
{
    public interface IAutomaticStation
    {
        Contract CreateNewContract(Client client, Tariff tariff, string phoneNumber);
    }
}
