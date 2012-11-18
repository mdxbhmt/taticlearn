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
        enum menuItems { EndTurn, Nothing };
        private static menuItems menuindex = menuItems.EndTurn;

        private static Dictionary<menuItems, String> menuitem = new Dictionary<menuItems, string> { { menuItems.Nothing, "Nothing" }, { menuItems.EndTurn, "End Turn" } };
        private static menuItems Next(menuItems item)
        {
            return ((menuItems)Math.Min((int)item+1,1));
        }
        private static menuItems Previous(menuItems item)
        {
            return ((menuItems)Math.Max((int)item - 1, 0));
        }
        
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
                        menuindex = Next(menuindex);
                    if (a.Key.Equals(ConsoleKey.DownArrow))
                        menuindex = Previous(menuindex);
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
        static void executeMenu(menuItems menuindex,gamemain game)
        {
            switch (menuindex)
            { case menuItems.EndTurn:
                    game.runturn();
                    break;
            }
        }

       static void PrintGame(gamemain game)
        {
            Console.Clear();
            Console.WriteLine("still running at {0}", game.turn);
            Console.Write(game.gameString());

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

    }
}
