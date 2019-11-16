using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediateka.interfaces;

namespace Mediateka.controls
{
    class UserList : Element, IMediaList
    {
        public ICollection<IElement> Items { get; set; }

        public UserList(string name, Guid id, double size, ICollection<IElement> items) : base (id, name, size)
        {
            Items = items;
        }

        void Sort()
        {

        }

    }
}
