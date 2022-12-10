namespace Day10.Commands
{
    internal class NoopCommand : Command
    {
        public NoopCommand()
        {
            CyclesLeft = 1;
        }

        public override int? Act(int registerValue)
        {
            return base.Act(registerValue);
        }
    }
}
