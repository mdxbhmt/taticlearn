using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class gamemain
    {
        public grid agrid;
        public int turn { get { return turn_; } }
        private int turn_;
        private GUImenu menu;
        private List<gameobject> objects;

        private Tuple<int , int> selectedindex;
        private bool seletection=false;    

        public gamemain()
        {
            agrid = new grid(10, 10);
            objects = new List<gameobject>();
            menu = new mainmenu(this);
                  
        }

        public void runturn()
        {
            turn_++;
        }

        public void Update(TimeSpan deltaT)
        {
            foreach (gameobject a in objects)
            {
                a.Update(deltaT);
            }
        }
        
        internal void UpKey()
        {
            menu.Next();
        }

        internal void DownKey()
        {
            menu.Previous();
        }

        internal void Enter()
        {
            menu.executeMenu();
        }

        internal void PrintGame()
        {
            Console.Clear();
            Console.WriteLine("still running at {0}", turn);

            gameGrid();
            menu.print();
        }      

        public  void gameGrid()
       {
           gridcell[,] thegrid = agrid.grid_;
           foreach (int i in Enumerable.Range(0, thegrid.GetLength(0)))
           {               
               foreach (int j in Enumerable.Range(0, thegrid.GetLength(1)))
               {
                   gridcell cell = thegrid[i, j];
                   if (cell == null)
                   {
                       Console.BackgroundColor = ConsoleColor.DarkBlue;
                       Console.Write(" ");
                       Console.ResetColor();
                       Console.Write(" ");
                   }
                   else
                   {
                       Console.BackgroundColor = thegrid[i, j].cellColor();
                       Console.ForegroundColor = ConsoleColor.Red;
                       Console.Write(thegrid[i, j].cellObject().representation());
                       Console.ResetColor();
                       Console.Write(" ");
                   }
                  
               }               
               Console.Write("\n");              
           }
       }
    }
}
