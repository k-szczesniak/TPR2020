using System;
using TestLib;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Kalkulator k = new Kalkulator(new Trace());
            int x = k.mnozenie(int.MaxValue, 1);
            Assert.Equal(int.MaxValue, x);

            Random r = new Random();
            x = k.mnozenie(r.Next(), 0);
            Assert.Equal(0, x);
        }
    }
}
