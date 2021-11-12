using System;
using System.Threading;

namespace L05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var count = 0;

            while (count < 5)
            {
                Console.WriteLine("Cycle no. " + count.ToString());
                Console.WriteLine("Date: " + DateTime.Now.ToLocalTime());

                ++count;
                Thread.Sleep(2000);
            }
        }
    }
}
