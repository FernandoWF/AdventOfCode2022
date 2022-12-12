namespace Day11
{
    internal class NonRelieverMonkey : Monkey
    {
        private readonly int testDivisorsFactor;

        public NonRelieverMonkey(
            IReadOnlyList<int> items,
            string operation,
            int testDivisor,
            int monkeyToThrowIfTrue,
            int monkeyToThrowIfFalse,
            int testDivisorsFactor)
            : base(items, operation, testDivisor, monkeyToThrowIfTrue, monkeyToThrowIfFalse)
        {
            this.testDivisorsFactor = testDivisorsFactor;
        }

        protected override int DecreaseWorryLevel(long worryLevel)
        {
            return (int)(worryLevel % testDivisorsFactor);
        }
    }
}
