using System;
using System.Collections.Generic;
using System.Linq;

namespace taticlearn
{
    class grid
    {
        gamemain game;
        gridcell[,] grid_;
        Tuple<int, int> selectedindex;
        public bool selection { get { return selection_; } set { selection_ = value; } }
        bool selection_ = false;
        public Dictionary<ConsoleKey, Action> keyMapping;

        public class SomeEventArgs : EventArgs { public Tuple<int, int> arg; public SomeEventArgs(Tuple<int, int> a) : base() { arg = a; } }

        public event EventHandler<SomeEventArgs> SimpleEvent;
        //public event EventHandler SimpleEvent;
        public void insertgrid(Igameobject obj, int x, int y)
        {
            grid_[x, y] = new gridcell(obj);
        }

        public grid(int x, int y, gamemain parent)
        {
            keyMapping = new Dictionary<ConsoleKey, Action>() {  { ConsoleKey.UpArrow, () => this.Up() }, 
                                                                 { ConsoleKey.DownArrow, () => this.Down() }, 
                                                                 { ConsoleKey.RightArrow, () => this.Right() }, 
                                                                 { ConsoleKey.LeftArrow, () => this.Left() },
                                                                 { ConsoleKey.Enter, () => this.exec()} };
            
            grid_ = new gridcell[x, y];
            selectedindex = Tuple.Create(0, 0);
            game = parent;
            
        }
        public void Up()
        { selectedindex = Tuple.Create(Math.Min(selectedindex.Item1 + 1, grid_.GetLength(0) - 1), selectedindex.Item2); }
        public void Down()
        { selectedindex = Tuple.Create(Math.Max(selectedindex.Item1 - 1, 0), selectedindex.Item2); }
        public void Right()
        { selectedindex = Tuple.Create(selectedindex.Item1, Math.Min(selectedindex.Item2 + 1, grid_.GetLength(1) - 1)); }
        public void Left()
        { selectedindex = Tuple.Create(selectedindex.Item1, Math.Max(selectedindex.Item2 - 1, 0)); }
        public void print()
        {
            foreach (int i in Enumerable.Range(0, grid_.GetLength(0)))
            {
                foreach (int j in Enumerable.Range(0, grid_.GetLength(1)))
                {
                    gridcell cell = grid_[i, j];
                    ConsoleColor? bkgcolor = null;
                    if (selection_)
                    {
                        if (selectedindex.Item1 == i && selectedindex.Item2 == j)
                            bkgcolor = ConsoleColor.White;
                    }
                    if (cell == null)
                    {
                        Console.BackgroundColor = bkgcolor ?? ConsoleColor.DarkBlue;
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = bkgcolor ?? cell.cellColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(cell.cellObject().representation());
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        internal void exec()
        {
            selection = false;
            
            SimpleEvent(this, new  SomeEventArgs(selectedindex));
        }

       public void moveFromTo(Tuple<int, int> from, Tuple<int, int> to)
        {
            grid_[to.Item1, to.Item2] = grid_[from.Item1, from.Item2];
            grid_[from.Item1, from.Item2] = null; 
        }
    }
}
