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

        public static void Main(string[] args)
        {
            gamemain game = new gamemain();
            Console.Title = "Tactics Grid";

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
           
            game.PrintGame();
            while (!_s_stop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo a = Console.ReadKey(true);

                    if (a.Key.Equals(ConsoleKey.UpArrow))
                        game.UpKey();
                    if (a.Key.Equals(ConsoleKey.DownArrow))
                        game.DownKey();
                    if (a.Key.Equals(ConsoleKey.Enter))
                        game.Enter();

                    game.PrintGame();

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
    }
}

