using Mediateka.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateka.controls
{
    class Mediateka
    {
        ICollection<IElement> Items { get; set; }
        ICollection<IMediaList> userLists { get; set; }

        public Mediateka(ICollection<IElement> items, ICollection<IMediaList> UserLists)
        {
            Items = items;
            userLists = UserLists;
        }
    }
}
