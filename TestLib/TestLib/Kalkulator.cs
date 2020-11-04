namespace TestLib
{
    public class Kalkulator
    {
        private ITracing _tracing;

        public Kalkulator(ITracing tracing)
        {
            _tracing = tracing;
        }

        public int mnozenie(int a, int b)
        {
            _tracing.WriteLine("Mnozenie");
            return a * b;
        }
    }
}
