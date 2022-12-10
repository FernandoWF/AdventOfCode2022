namespace Day10.Commands
{
    internal abstract class Command
    {
        public int CyclesLeft { get; protected set; }
        public bool FinishedExecuting => CyclesLeft == 0;

        public virtual int? Act(int registerValue)
        {
            if (CyclesLeft < 1) { throw new InvalidOperationException("The command already finished executing"); }
            else { CyclesLeft--; }

            return default;
        }
    }
}
