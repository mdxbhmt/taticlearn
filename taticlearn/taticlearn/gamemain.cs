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

        public gamemain()
        {
            grid = new gameobject[10, 10];
            grid[3,1]= new npc();
        }

        public void runturn()
        {
            turn_++;
        }

        public String gameString()
        {
            StringBuilder gameString = new StringBuilder();
            foreach (int i in Enumerable.Range(0, grid.GetLength(0)))
            {
                foreach (int j in Enumerable.Range(0, grid.GetLength(1)))

                    gameString.Append((grid[i, j] == null) ? " o " : (" "+grid[i, j].representation())+" ");
                gameString.Append("\n");
            }
            return gameString.ToString();
        }

    }
}
