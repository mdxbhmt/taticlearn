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
            bool mathieugay = true;

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            while (!_s_stop)
            {
                /* put real logic here */
                Console.WriteLine("still running at {0}", game.turn);
                game.runturn();
                Thread.Sleep(3000);
            }
            Console.WriteLine("Graceful shut down code here...");

            //don't leave this...  demonstration purposes only...
            Console.ReadLine();
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //you have 2 options here, leave e.Cancel set to false and just handle any
            //graceful shutdown that you can while in here, or set a flag to notify the other
            //thread at the next check that it's to shut down.  I'll do the 2nd option
            e.Cancel = true;
            _s_stop = true;
            Console.WriteLine("CancelKeyPress fired...");
        }


    }
}
