namespace XUnitsTests.Data
{
    internal class MultiplicationCalculator : ICalculator
    {
        public int Calc(int x, int y)
        {
            return x * y; // different behaviour
        }
    }
}
