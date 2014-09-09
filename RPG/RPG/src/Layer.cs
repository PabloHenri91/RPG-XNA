using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.src
{
    class Layer
    {
        public ushort type;
        public ushort[] data;

        public Layer(ushort type)
        {
            this.type = type;
        }
    }
}
