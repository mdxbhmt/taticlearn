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

        private static int menuindex = 0;

        private static List<String> menuitem = new List<String> { "End Turn", "Nothing" };

        public static void Main(string[] args)
        {
            gamemain game = new gamemain();


            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            ConsoleKeyInfo a;
            while (!_s_stop)
            {
                if (Console.KeyAvailable)
                {
                    a = Console.ReadKey(true);
                
                    if (a.Key.Equals(ConsoleKey.UpArrow))
                        menuindex = Math.Min(1, menuindex+1);
                    if (a.Key.Equals(ConsoleKey.DownArrow))
                        menuindex = Math.Max(0, menuindex-1);
                    if (a.Key.Equals(ConsoleKey.Enter))
                        executeMenu(menuindex,game);
                   
                }
                PrintGame(game);
                Thread.Sleep(100);
            }
            Console.WriteLine("Graceful shut down code here...");

        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {

            e.Cancel = true;
            _s_stop = true;
            Console.WriteLine("CancelKeyPress fired...");
        }
        static void executeMenu(int menuindex,gamemain game)
        {
            switch (menuindex)
            { case 0:
                    game.runturn();
                    break;
            }
        }

       static void PrintGame(gamemain game)
        {
            Console.Clear();
            Console.WriteLine("still running at {0}", game.turn);
            Console.Write(game.gameString());
           
            foreach (int i in Enumerable.Range( 0,menuitem.Count()).Reverse())
            {
                if (i == menuindex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(menuitem[i]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(menuitem[i]);

            }
        }

    }
}
