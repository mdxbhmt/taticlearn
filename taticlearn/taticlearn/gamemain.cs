using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    
    class gamemain
    {
        private gameobject[,] grid;
        public int turn { get { return turn_; } }
        private int turn_;

        public gamemain() { 
        grid = new gameobject[10,10];
        }

        public void runturn()
        {
        turn_++;
        }

    }
}
