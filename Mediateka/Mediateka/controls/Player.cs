using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mediateka.interfaces;

namespace Mediateka
{
     class Player : IPlayable, IMediaList
    {
        public ICollection<IElement> Items { get; set; }

        public Player()
        {

        }

        public void Play()
        {

        }

        public void Stop()
        {

        }
    }
}