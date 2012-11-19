using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace taticlearn
{
    class Program
    {
        private static bool _s_stop = false;

        public static void Main(string[] args)
        {
            gamemain game = new gamemain();
            Console.Title = "Tactics Grid";
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            while (!_s_stop)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                game.PrintGame();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo a = Console.ReadKey(true);

                    game.keyInput(a.Key);

                    while (Console.KeyAvailable)
                        Console.ReadKey(true);
                }
                Thread.Sleep(100);
                stopwatch.Stop();
                game.Update(stopwatch.Elapsed);
            }
            Console.WriteLine("\n See ya, Space Cowboy...");
            Thread.Sleep(3000);
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _s_stop = true;
            Console.Clear();
            Console.WriteLine("Closing...");
        }
    }
}

