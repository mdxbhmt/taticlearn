using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace taticlearn
{
    class Program
    {
        private static bool _s_stop = false;
        enum menuItems { EndTurn, Select, Nothing };
        private static menuItems menuindex = menuItems.EndTurn;

        private static Dictionary<menuItems, String> menuitem = new Dictionary<menuItems, string> { { menuItems.Nothing, "Nothing" },{menuItems.Select, "Select"}, { menuItems.EndTurn, "End Turn" } };
        private static menuItems Next(menuItems item)
        {
            return ((menuItems)Math.Min((int)item + 1, 1));
        }
        private static menuItems Previous(menuItems item)
        {
            return ((menuItems)Math.Max((int)item - 1, 0));
        }

        public static void Main(string[] args)
        {
            gamemain game = new gamemain();
            Console.Title = "Tactics Grid";

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            ConsoleKeyInfo a;
            PrintGame(game);
            while (!_s_stop)
            {
                if (Console.KeyAvailable)
                {
                    a = Console.ReadKey(true);

                    if (a.Key.Equals(ConsoleKey.UpArrow))
                        menuindex = Next(menuindex);
                    if (a.Key.Equals(ConsoleKey.DownArrow))
                        menuindex = Previous(menuindex);
                    if (a.Key.Equals(ConsoleKey.Enter))
                        executeMenu(menuindex, game);
                    PrintGame(game);

                    while (Console.KeyAvailable)
                        Console.ReadKey(true);
                    
                }
                
                Thread.Sleep(100);
            }
            Console.WriteLine("\n See ya, Space Cowboy...");
            Thread.Sleep(3000);

        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {

            e.Cancel = true;
            _s_stop = true;
            Console.WriteLine("Closing...");
        }
        static void executeMenu(menuItems menuindex, gamemain game)
        {
            switch (menuindex)
            {
                case menuItems.EndTurn:
                    game.runturn();
                    break;
            }
        }

        static void PrintGame(gamemain game)
        {
            Console.Clear();
            Console.WriteLine("still running at {0}", game.turn);

            gameGrid(game);
            gameMenu();
        }

        private static void gameMenu()
        {
            foreach (KeyValuePair<menuItems, String> pair in menuitem)
            {
                if ((pair.Key) == menuindex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(pair.Value);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(pair.Value);

            }
        }
        public static void gameGrid(gamemain game)
       {
           gridcell[,] thegrid = game.grid.grid_;
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
                       Console.BackgroundColor = thegrid[i, j].cell_.Item2;
                       Console.ForegroundColor = ConsoleColor.Red;
                       Console.Write(thegrid[i, j].cell_.Item1.representation());
                       Console.ResetColor();
                       Console.Write(" ");
                   }
                  
               }
               
               Console.Write("\n");
              
           }

       }
    }



}

