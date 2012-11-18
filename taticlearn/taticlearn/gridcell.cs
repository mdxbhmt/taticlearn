using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class gridcell
    {
        public Tuple<gameobject, ConsoleColor> cell_;
        public gridcell(gameobject cellobject) { cell_ = Tuple.Create(cellobject, ConsoleColor.Green); }
    }
}
