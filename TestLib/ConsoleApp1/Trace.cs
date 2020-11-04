using System;
using TestLib;

namespace ConsoleApp1
{
    public class Trace : ITracing
    {
        public void WriteLine(string log)
        {
            Console.WriteLine(log);
        }
    }
}
