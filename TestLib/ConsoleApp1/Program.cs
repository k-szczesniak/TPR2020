using System;
using TestLib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Kalkulator k = new Kalkulator(new Trace());
            int y = 5;
            int x = k.mnozenie(y, 5);
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
