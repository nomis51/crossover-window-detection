using System;
using System.Threading;
using CrossOver.WindowDetection.Models;

namespace CrossOver.WindowDetection.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var wd = new WindowDetection();
            while (true)
            {
                if (wd.GetForegroundWindowInfos(null).Result is WindowInfos result)
                {
                    Console.WriteLine($"Title: {result.Title}");
                    Console.WriteLine($"Process path: {result.ProcessPath}");
                    Console.WriteLine();
                }

                Thread.Sleep(500);
            }
        }
    }
}