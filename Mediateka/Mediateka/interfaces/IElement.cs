using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.interfaces
{
    interface IElement
    {
        string Name { get; set; }
        Guid Id { get; }
        double Size { get; }
    }
}
