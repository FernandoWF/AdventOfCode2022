namespace Day5
{
    internal class RearrangementStep
    {
        public int QuantityToMove { get; }
        public int SourceStack { get; }
        public int TargetStack { get; }

        public RearrangementStep(int quantityToMove, int sourceStack, int targetStack)
        {
            QuantityToMove = quantityToMove;
            SourceStack = sourceStack;
            TargetStack = targetStack;
        }
    }
}
