using System;
using System.Threading;
using System.Diagnostics;
namespace taticlearn
{
    class Program
    {
        private static bool _s_stop = false;
        private static TimeSpan sleeperror = new TimeSpan();
        public static void Main(string[] args)
        {

            Console.Title = "Tactical Grid";
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);


            gamemain game = new gamemain();
            TimeSpan deltaT = new TimeSpan();
            //List<TimeSpan> List = new List<TimeSpan>();
            //List<TimeSpan> List2 = new List<TimeSpan>();
            //List2.Add(TimeSpan.Zero);
            //List<TimeSpan> List3 = new List<TimeSpan>();
            var AbsTime = Stopwatch.StartNew();
            while (!_s_stop)
            {
                
                var stopwatch = Stopwatch.StartNew();
                var timetosleep = new TimeSpan(0, 0, 0, 0, 100) - sleeperror;
                game.Update(deltaT);
                game.PrintGame();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo a = Console.ReadKey(true);

                    game.keyInput(a.Key);

                    while (Console.KeyAvailable)
                        Console.ReadKey(true);

                }
                Thread.Sleep(timetosleep); // this can be omitted but CPU Utilization skyrockets
                //List.Add(timetosleep);
                //List2.Add(AbsTime.Elapsed);
                //List3.Add(game.GameTime);
                stopwatch.Stop();
                sleeperror = stopwatch.Elapsed - timetosleep;
                deltaT = stopwatch.Elapsed;

            }


            //var compound= List2.Zip(List3, (first, second) => first.ToString() + "--" + second.ToString());

            //foreach( var a in compound)
            //    Console.WriteLine(a);
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

