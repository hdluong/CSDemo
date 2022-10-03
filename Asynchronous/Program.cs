using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static void DoSomeThing(int seconds, string msg, ConsoleColor color)
        {
            lock(Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} ... Start");
                Console.ResetColor();
            }

            for (int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,10} {i,2}");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} ... End");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(15, "T2", ConsoleColor.Green);
                }
            );

            Task t3 = new Task(
                (Object obj) =>
                {
                    string tentacvu = (string)obj;
                    DoSomeThing(4, tentacvu, ConsoleColor.Yellow);
                }
                , "T3"
            );

            t2.Start();
            t3.Start();
            DoSomeThing(6, "T1", ConsoleColor.Magenta);

            t2.Wait();
            t3.Wait();

            //Console.WriteLine("Press any key");
            //Console.ReadKey();
        }
    }
}
