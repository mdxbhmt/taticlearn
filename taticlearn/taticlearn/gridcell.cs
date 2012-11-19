using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class gridcell
    {
        private Tuple<gameobject, ConsoleColor> cell_;
        public gridcell(gameobject cellobject) { cell_ = Tuple.Create(cellobject, ConsoleColor.Green); }
        public gameobject  cellObject() { return cell_.Item1; }
        public ConsoleColor cellColor() { return cell_.Item2; }
    }
}
