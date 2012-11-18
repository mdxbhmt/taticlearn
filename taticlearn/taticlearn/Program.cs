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


            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            while (!_s_stop)
            {
                Console.Clear();
                Console.WriteLine("still running at {0}", game.turn);
                Console.Write(game.gameString());
                game.runturn();
                Thread.Sleep(3000);
            }
            Console.WriteLine("Graceful shut down code here...");

            Console.ReadLine();
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {

            e.Cancel = true;
            _s_stop = true;
            Console.WriteLine("CancelKeyPress fired...");
        }


    }
}
