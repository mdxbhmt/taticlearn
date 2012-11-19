using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class grid
    {
        public gridcell[,] grid_;

        public  grid(int x, int y)
        {
            grid_ = new gridcell[x, y];
            grid_[3, 1] = new gridcell(new npc());
        }    
    }
}
