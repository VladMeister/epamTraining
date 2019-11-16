using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediateka.interfaces;

namespace Mediateka.controls
{
    abstract class AudioElement : Element, IMediaStreamable, IDurationable
    {
       public FileInfo fileInfo { get; set; }
       public StreamReader Stream { get; set; }
       public TimeSpan Duration { get; }

        public AudioElement(string name, Guid id, double size, FileInfo FileInfo, StreamReader stream) : base(id, name, size)
        {
            fileInfo = FileInfo;
            Stream = stream;
        }
    }
}
