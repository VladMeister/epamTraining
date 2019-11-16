using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediateka.interfaces;

namespace Mediateka.controls
{
    abstract class Element : IElement
    {
       public Guid Id { get; }
       public string Name { get; set; }
       public double Size { get; }

       public Element(Guid id, string name, double size)
        {
            Id = id;
            Name = name;
            Size = size;
        }
    }
}
