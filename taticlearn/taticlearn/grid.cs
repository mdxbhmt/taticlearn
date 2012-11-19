using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class grid
    {
        gridcell[,] grid_;
        Tuple<int, int> selectedindex;
        bool seletection = true;

        public void insertgrid(gameobject obj)
        {
            grid_[3, 1] = new gridcell(obj);
        }

        public grid(int x, int y)
        {
            grid_ = new gridcell[x, y];
            selectedindex = Tuple.Create(4, 1);
        }
        public void print()
        {
            foreach (int i in Enumerable.Range(0, grid_.GetLength(0)))
            {
                foreach (int j in Enumerable.Range(0, grid_.GetLength(1)))
                {
                    gridcell cell = grid_[i, j];
                    ConsoleColor? bkgcolor = null;
                    if (seletection)
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
    }
}
